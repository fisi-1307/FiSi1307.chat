Option Strict On

Imports System.Threading

''' <summary>
''' Responsible for handling the channel nicks ListView IRC events
''' </summary>
''' <remarks></remarks>

Public Class NickList

#Region " Private Members "
    Private WithEvents _ircClient As InitiateConnection
    Private _mainView As MainView
#End Region

#Region " Constructor "
    Public Sub New(ByVal mainView As MainView, ByVal ircClient As InitiateConnection)
        _mainView = mainView
        _ircClient = ircClient
    End Sub
#End Region

#Region " Events "
    Public Event UpdateNickListEventArghs As EventHandler
    Public Event NickUpdate As EventHandler
#End Region

#Region " Event Handlers "
    Private Sub InitiateThread(ByVal nicks As String) Handles _ircClient.NameListEventArgs
        Dim t As New Thread(DirectCast(Sub() DoWorkChannelNicks(nicks), ThreadStart))
        t.Start()
    End Sub

    ''' <summary>
    ''' Handles all incoming events to parse to individual methods.
    ''' </summary>
    ''' <param name="serverResponse">The server response.</param>
    ''' <remarks></remarks>
    Private Sub ServerResponse(ByVal serverResponse As String) Handles _ircClient.NickListUpdateEventArghs
        Dim splitResponse() As String = serverResponse.Split(" "c)
        Dim nick As String = splitResponse(0)

        Select Case serverResponse.Split(" "c)(1)
            Case "JOIN" : AddUser(AddressSplit(nick, 0))
            Case "PART", "QUIT" : RemoveUser(AddressSplit(nick, 0))
        End Select
    End Sub
#End Region

#Region " Private Methods"
    ''' <summary>
    ''' Handles IRC raw 353 channel nicks on join.
    ''' </summary>
    ''' <param name="users">The channels users.</param>
    ''' <remarks>
    ''' Splits returned channel nicks and updates the ListView according to IRC channel
    ''' status.
    ''' </remarks>
    Private Sub DoWorkChannelNicks(ByVal users As String)
        Dim nicks() As String = users.Split(" "c)

        ' Begin ListView update.
        Update(True)

        For Each nick As String In nicks
            If Not String.IsNullOrEmpty(nick) Then
                AddUser(nick)
            End If
        Next

        Update(False)

    End Sub

    Private Sub Update(ByVal value As Object)
        Dim lvw As ListView = _mainView.lvwChannelUsers

        If lvw.InvokeRequired Then
            lvw.Invoke(New System.Threading.ParameterizedThreadStart(AddressOf Update), value)
        Else
            If DirectCast(value, Boolean) Then
                lvw.BeginUpdate()
            Else
                lvw.EndUpdate()
            End If
        End If
    End Sub

    Public Sub AddUser(ByVal name As Object)
        If _mainView.lvwChannelUsers.InvokeRequired Then
            _mainView.lvwChannelUsers.Invoke(New ParameterizedThreadStart(AddressOf AddUser), name)
        Else
            Dim lvi As New ListViewItem
            lvi.Text = DirectCast(name, String)
            _mainView.lvwChannelUsers.Items.Add(lvi)
        End If
    End Sub

    Public Sub RemoveUser(ByVal name As Object)
        If _mainView.lvwChannelUsers.InvokeRequired Then
            _mainView.lvwChannelUsers.Invoke(New ParameterizedThreadStart(AddressOf RemoveUser), name)
        Else
            Dim lvi As ListViewItem = GetListViewItemsIndex(DirectCast(name, String))
            _mainView.lvwChannelUsers.Items.Remove(lvi)
        End If
    End Sub
#End Region

#Region " Functions "
    ' TODO: Is this function needed?
    ''' <summary>
    ''' Loops threw each nick in the ListView and returns nicks
    ''' </summary>
    ''' <param name="name">The users nick.</param>
    ''' <returns>True if matched. Nothing if False.</returns>
    ''' <remarks></remarks>
    Private Function GetListViewItemsIndex(ByVal name As String) As ListViewItem
        For Each n As ListViewItem In _mainView.lvwChannelUsers.Items
            If n.Text = name Then
                Return n
            End If
        Next
        Return Nothing
    End Function

    Private Function AddressSplit(ByVal address As String, ByVal part As Integer) As String
        Return address.Split("!"c)(part)
    End Function

    Private Function indexOf(ByVal s As String, ByVal instance As Integer) As Integer
        Dim startAt As Integer = -1
        For x As Integer = 1 To instance
            startAt = s.IndexOf(" "c, startAt + 1)
        Next
        Return startAt
    End Function
#End Region

End Class