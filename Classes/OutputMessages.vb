Option Strict On

Imports FiSi1307_IRC_Client.Delegates
Imports System.Text.RegularExpressions

''' <summary>
''' Handles minimal IRC server response messages.
''' </summary>

Public Class OutputMessages : Implements IDisposable

#Region " Private Members "
    Private ReadOnly ColorQuit As Color = Color.FromArgb(102, 54, 31)
    Private ReadOnly ColorPrivmsg As Color = Color.FromArgb(76, 76, 76)
    Private ReadOnly ColorTopic As Color = Color.FromArgb(176, 55, 176)
    Private ReadOnly ColorKick As Color = Color.FromArgb(199, 50, 50)
    Private ReadOnly ColorUserEvent As Color = Color.FromArgb(128, 128, 128)
    Private WithEvents _ircConnection As InitiateConnection
    Private _mainView As MainView
    Private _window As RichTextBox
#End Region

#Region " Constructor "
    Public Sub New(ByVal mainView As MainView, ByVal ircConnection As InitiateConnection)
        _mainView = mainView
        _ircConnection = ircConnection
        _window = _mainView.rtbChannelView
    End Sub
#End Region

#Region " EventArghs "

    Private Sub ServerResponse(ByVal serverResponse As String) Handles _ircConnection.ServerResponseOutputEventArghs

        ' This setting has only been added for demonstration purposes of what raw data
        ' looks like.
        If _mainView.mnuMainMenuOptionsrawData.Checked Then
            OutputResponse(_window, serverResponse, Color.Black)
            Exit Sub
        End If

        Dim parts() As String = serverResponse.Split(" "c)
        Dim address As String = parts(0)

        Select Case parts(1)
            Case "PRIVMSG" : Privmsg(address, serverResponse.Substring(indexOf(serverResponse, 3) + 1).Substring(1))
            Case "JOIN" : Join(address)
            Case "PART", "QUIT" : Quit(address)
            Case "ERROR" : Disconnected()
            Case "332" : TopicOnjoin(serverResponse.Substring(indexOf(serverResponse, 4) + 1).Substring(1))
        End Select
    End Sub
#End Region

#Region " Private"

    ''' <summary>
    ''' Outputs a GUI message on me/user Privmsg.
    ''' </summary>
    ''' <param name="address">The source of the user's local host.</param>
    ''' <param name="message">The message text.</param>
    ''' <remarks>
    ''' Displays an output message to the normalview window with correct format and colouring on Me, 
    ''' User Privmsg.
    ''' </remarks>
    Private Sub Privmsg(ByVal address As String, ByVal message As String)
        Dim outputFormat As String = String.Format("<{0}> {1}", Split(address), message)
        OutputResponse(_window, outputFormat, Color.Black)
    End Sub

    Private Sub Join(ByVal address As String)
        If Split(address) = ConnectionInformation.ChannelNick Then
            Exit Sub
        End If

        Dim outputFortmat As String = String.Format("{0} has joined the conversation.", Split(address))
        OutputResponse(_window, outputFortmat, ColorUserEvent)
    End Sub

    ''' <summary>
    ''' Outputs a GUI message on user Quitting.
    ''' </summary>
    ''' <param name="address">The source of the user's local host.</param>
    ''' <remarks>
    ''' Displays an output message to the normalview window with correct format on user Quitting with Quit message.
    ''' </remarks>
    Private Sub Quit(ByVal address As String)
        Dim outputFortmat As String = String.Format("{0} has left the conversation.", Split(address))
        OutputResponse(_window, outputFortmat, ColorUserEvent)
    End Sub

    Private Sub Disconnected()
        Dim outputFortmat As String = "Disconnected!"
        OutputResponse(_window, outputFortmat, Color.Red)
    End Sub

    Private Sub TopicOnjoin(ByVal subject As String)
        OutputResponse(_window, String.Format("The chat's topic is: {0} ", subject), Color.Black)
        NewLine()
    End Sub
#End Region

#Region " Output Response "
    ''' <summary>
    ''' Displays the servers output response message.
    ''' </summary>
    ''' <param name="control">The control name.</param>
    ''' <param name="output">The server output.</param>
    ''' <param name="color">The control output line color</param>
    ''' <remarks>
    ''' Responsible for displaying all server and user response messages.
    ''' </remarks>
    Public Sub OutputResponse(ByVal control As RichTextBox, ByVal output As String, ByVal color As Color)
        Dim outputFormat As String = String.Format("{0}", output)

        If control.InvokeRequired Then
            control.Invoke(New OutputEventHandler(AddressOf OutputResponse), control, output, color)
        Else
            Dim start = control.TextLength
            Dim length = outputFormat.Length

            With control
                .AppendText(outputFormat & Environment.NewLine)
                .ScrollToCaret()
                .Select(start, length)
                .SelectionColor = color
            End With
        End If
    End Sub

    Private Sub NewLine()
        If _window.InvokeRequired Then
            _window.Invoke(New MethodInvoker(AddressOf NewLine))
        Else
            _window.AppendText(Environment.NewLine)
        End If
    End Sub

#End Region

#Region " Functions "
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="instance"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function indexOf(ByVal s As String, ByVal instance As Integer) As Integer
        Dim startAt As Integer = -1
        For x As Integer = 1 To instance
            startAt = s.IndexOf(" "c, startAt + 1)
        Next
        Return startAt
    End Function

    Private Function Split(ByVal name As String) As String
        Return name.Split("!"c)(0)
    End Function
#End Region

#Region " IDisposable "
    Public Sub dispose() Implements IDisposable.Dispose

    End Sub
#End Region

End Class
