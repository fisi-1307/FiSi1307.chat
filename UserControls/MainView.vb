Option Strict On

''' <summary>
''' Responsible for handling connecting and disconnecting from the server.
''' </summary>

Public Class MainView : Implements IDisposable

#Region " Private Members "
    Private WithEvents _ircConnection As InitiateConnection
    Private _disposed As Boolean
#End Region

#Region " EventArghs "
    Private Sub Disconnected() Handles _ircConnection.DisconnectedEventArghs
        MessageBox.Show("Disconnected", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        _ircConnection = Nothing
    End Sub
#End Region

#Region " Methods "
    Private Sub Connect()
        ' Check we are not connected.
        If _ircConnection IsNot Nothing AndAlso _ircConnection.IsConnected Then
            Exit Sub
        End If

        ' Create a new instance each time to keep the connection clean.
        _ircConnection = New InitiateConnection(Me)
        _ircConnection.InitializeThread()
    End Sub

    Private Sub Disconnect()
        If _ircConnection IsNot Nothing Then _ircConnection.Dispose()
        Me.lvwChannelUsers.Items.Clear()
        Me.rtbChannelView.Clear()
    End Sub
#End Region

#Region " Menu "
    Private Sub mnuMainMenuConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainMenuConnect.Click
        Connect()
    End Sub

    Private Sub mnuMainMenuDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainMenuDisconnect.Click
        Disconnect()
    End Sub

    Private Sub mnuMainMenuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainMenuFileExit.Click
        Disconnect()
        Application.Exit()
    End Sub

    Private Sub mnuMainMenuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainMenuAbout.Click
        frmAbout.Show()
    End Sub
#End Region

#Region "IDisposable "
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If Not _disposed Then
                Disconnect()
            End If
        Finally
            _disposed = True
            MyBase.Dispose(disposing)
        End Try
    End Sub
#End Region

End Class
