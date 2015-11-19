Option Strict On

Imports FiSi1307_IRC_Client.Delegates
Imports System.IO
Imports System.Threading
Imports System.Net.Sockets
Imports System.Net




Public Class InitiateConnection : Implements IDisposable

#Region " Private Members "
    Private _tcpClient As TcpClient
    Private _stream As NetworkStream
    Private _streamWriter As StreamWriter
    Private _output As OutputMessages
    Private _nickList As NickList
    Private _mainView As MainView
    Private _channelNicks As String
    Private _keepAlive As Boolean
#End Region

#Region " Properties "
    ' Gets if the TCP client is connected.
    Public ReadOnly Property IsConnected() As Boolean
        Get
            If _tcpClient IsNot Nothing Then
                Return _tcpClient.Connected
            End If

            Return False
        End Get
    End Property
#End Region

#Region "Constructor"
    Public Sub New(ByVal mainView As MainView)
        _mainView = mainView
        _output = New OutputMessages(_mainView, Me)
    End Sub
#End Region

#Region " Events "
    Public Event ServerResponseOutputEventArghs As ServerResponseOutputEventHandler
    Public Event NameListEventArgs As NamesListEventHandler
    Public Event NickListUpdateEventArghs As NickListUpdateEventHandler
    Public Event DisconnectedEventArghs As EventHandler
#End Region

#Region " Methods "
    Public Sub InitializeThread()
        _keepAlive = True

        ' Thread is responsible for obtaining the networks ident response code.
        ' Requiered for authenticated login.
        Dim threadIdent As New Thread(AddressOf DoWorkIdent)
        ' Thread is responsible for handling all incoming network messages.
        Dim threadInitializeConnection As New Thread(AddressOf InitializeConnection)

        Try
            _tcpClient = New TcpClient(ConnectionInformation.Server, ConnectionInformation.port)
        Catch ex As SocketException
            MessageBox.Show(ex.Message)
            _keepAlive = False
        End Try

        ' Send authentication to the network.
        SendMessage(String.Format("USER {0} {1} * :{2}", ConnectionInformation.UserName, 8, ConnectionInformation.RealName))
        SendMessage(String.Format("NICK {0}", ConnectionInformation.ChannelNick))

        threadInitializeConnection.IsBackground = True
        threadInitializeConnection.Start()

        threadIdent.IsBackground = True
        threadIdent.Start()
    End Sub

    Public Sub SendMessage(ByVal msg As String)
        Dim stream As NetworkStream = _tcpClient.GetStream
        Dim sw As StreamWriter

        Try
            SyncLock _tcpClient.GetStream
                sw = New StreamWriter(_tcpClient.GetStream)
                sw.WriteLine(If(msg.StartsWith("/"), msg.Substring(1), msg))
                sw.Flush()
            End SyncLock
        Catch ex As IOException
            MessageBox.Show(ex.Message)
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

#Region " Private "

#Region " Main Response Handler "
    Private Sub InitializeConnection()
        Dim serverResponse As String = String.Empty
        Dim nws As NetworkStream = _tcpClient.GetStream
        Dim sr As New StreamReader(nws)

        While _keepAlive
            Try
                serverResponse = sr.ReadLine()
            Catch ex As IOException
                MessageBox.Show(ex.Message)
            End Try

            If serverResponse.StartsWith(":") Then serverResponse = serverResponse.Substring(1)
            Debug.WriteLine(serverResponse)

            ' This setting has only been added for demonstration purposes of what raw data
            ' looks like.
            If _mainView.mnuMainMenuOptionsrawData.Checked Then
                RaiseEvent ServerResponseOutputEventArghs(serverResponse)
            Else
                Select Case serverResponse.Split(" "c)(1)
                    Case "001" : Connected()
                    Case "332", "TOPIC", "PRIVMSG" : RaiseEvent ServerResponseOutputEventArghs(serverResponse)
                    Case "JOIN", "PART", "QUIT" : NickListUpdate(serverResponse)
                    Case "353" : ChannelNames(serverResponse)
                    Case "366" : EndOfChannelNames()
                End Select
            End If

            Select Case serverResponse.Split(" "c)(0)
                Case "PING", "PONG" : Ping(serverResponse)
                Case "ERROR" : RaiseEvent DisconnectedEventArghs(serverResponse, EventArgs.Empty)
            End Select
        End While

        ' Close client here rather then IDisposable to avoid IOException during reading.
        If _tcpClient IsNot Nothing AndAlso _tcpClient.Connected Then
            _tcpClient.Close()
        End If
    End Sub
#End Region

#Region " Raw Numeric's "
    Private Sub Connected()
        If Not _mainView.mnuMainMenuOptionsrawData.Checked Then
            _output.OutputResponse(_mainView.rtbChannelView, String.Format("Connected{0}", Environment.NewLine), Color.FromArgb(199, 50, 50))
        End If

        JoinChannelIfSettingReflects()
    End Sub

    ''' <summary>
    ''' Handles Raw Numeric 353 Channel Names.
    ''' </summary>
    ''' <param name="serverResponse">The servers output message.</param>
    ''' <remarks>
    ''' Responsible for splitting the channel names and storing them for later use. 
    ''' ServerInformation module is also updated here to handle nick count.
    ''' </remarks>
    Private Sub ChannelNames(ByVal serverResponse As String)
        _channelNicks &= serverResponse.Substring(indexOf(serverResponse, 5) + 1).Substring(1)
    End Sub

    ''' <summary>
    ''' Handles Raw Numeric 366 End of /NAMES list.
    ''' </summary>
    ''' <remarks>
    ''' 
    ''' </remarks>
    Private Sub EndOfChannelNames()
        If _nickList Is Nothing Then
            _nickList = New NickList(_mainView, Me)
        End If

        RaiseEvent NameListEventArgs(_channelNicks)
        _channelNicks = String.Empty
    End Sub

    ''' <summary>
    ''' Handles Raw Numeric 376 End of /MOTD command.
    ''' </summary>
    ''' <remarks>
    ''' Responsible for creating a new frmJoinChannel dialogue. We call this here to prevent race conditions
    ''' allowing server information to finish.
    ''' </remarks>
    Private Sub JoinChannelIfSettingReflects()
        ' Note: I left this in to show where i would send the join command.
        SendMessage(String.Format("JOIN {0}", ConnectionInformation.Channel))
    End Sub

    ''' <summary>
    ''' Handles Raw Numeric's 431 and 433 No Nick Give/Nick in Use.
    ''' </summary>
    ''' <param name="serverResponse">The servers output message.</param>
    ''' <remarks>
    ''' Responsible for handling if no nick has been parsed to the server. If nick is
    ''' in use will attempt to try the next and so on. Finalizing on a random nick if needed.
    ''' </remarks>
    Private Sub NickInUse(ByVal serverResponse As String)
        SendMessage("NICK " & ConnectionInformation.ChannelAltNick) : ConnectionInformation.ChannelNick = ConnectionInformation.ChannelAltNick
    End Sub

#End Region

#Region " NickList EventArghs"
    Private Sub NickListUpdate(ByVal serverResponse As String)
        RaiseEvent ServerResponseOutputEventArghs(serverResponse)
        RaiseEvent NickListUpdateEventArghs(serverResponse)
    End Sub
#End Region

#Region " Misc "
    Private Sub Ping(ByVal serverResponse As String)
        SendMessage(String.Format("PONG {0}", serverResponse.Split(" "c)(1)))
    End Sub

    Private Sub DoWorkIdent()
        Dim client As TcpClient = Nothing
        Dim clientListener As TcpListener = Nothing
        Dim sr As StreamReader = Nothing
        Dim sw As StreamWriter = Nothing
        Dim stream As NetworkStream = Nothing
        Dim response As String = String.Empty

        Try
            clientListener = New TcpListener(IPAddress.Any, 113)
            clientListener.Start()
            client = clientListener.AcceptTcpClient
            clientListener.Stop()
        Catch ex As SocketException
            MessageBox.Show(ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        If client.GetStream IsNot Nothing Then
            stream = client.GetStream
        End If

        sr = New StreamReader(stream)
        response = sr.ReadLine

        If Not String.IsNullOrEmpty(response) Then
            sw = New StreamWriter(stream)
            sw.WriteLine(String.Format("{0} : USERID : UNIX : {1}", response, ConnectionInformation.UserName))
            sw.Flush()
        End If

        stream.Dispose()
        sr.Dispose()
        sw.Dispose()
    End Sub
#End Region

#End Region

#End Region

#Region " Functions "
    Private Function indexOf(ByVal s As String, ByVal instance As Integer) As Integer
        Dim startAt As Integer = -1
        For x As Integer = 1 To instance
            startAt = s.IndexOf(" "c, startAt + 1)
        Next
        Return startAt
    End Function
#End Region

#Region " IDisposable "
    Public Sub Dispose() Implements IDisposable.Dispose
        If _tcpClient IsNot Nothing AndAlso _tcpClient.Connected Then
            SendMessage("QUIT")
        End If

        _keepAlive = False

        If _output IsNot Nothing Then
            _output.dispose()
        End If

        GC.Collect()
    End Sub
#End Region

End Class
