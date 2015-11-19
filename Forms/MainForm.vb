Option Strict On

Public Class MainForm

#Region " Private Members "
    Private _mainView As MainView
#End Region

#Region " Form Events "
    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        _mainView.Dispose()
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetConnectionInformation()
        LoadStartUpControl()
    End Sub
#End Region

#Region " Private Methods "
    Private Sub LoadStartUpControl()
        If _mainView Is Nothing Then
            _mainView = New MainView
        End If

        Me.PanelUserControlHolder.Controls.Add(_mainView)
    End Sub


    Private m_rng As New Random
    Private Sub SetConnectionInformation()
        '  Join this server & channel.
        ConnectionInformation.Server = "irc.quakenet.org"
        ConnectionInformation.Channel = "#fisi1307"
        ConnectionInformation.ChannelNick = "fisi1307_" & m_rng.Next(0, 999)
        ConnectionInformation.ChannelAltNick = "ident_" & m_rng.Next(0, 999)
        ConnectionInformation.UserName = "ident"
        ConnectionInformation.RealName = "fisiuser"
    End Sub
#End Region

End Class
