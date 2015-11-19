<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainView
    Inherits System.Windows.Forms.UserControl

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lvwChannelUsers = New System.Windows.Forms.ListView()
        Me.colChannelUsers = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rtbChannelView = New System.Windows.Forms.RichTextBox()
        Me.mnuMainMenu = New FiSi1307_IRC_Client.MenuStripTrans()
        Me.mnuMainMenuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainMenuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainMenuConnect = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainMenuDisconnect = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainMenuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainMenuOptionsrawData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainMenuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwChannelUsers
        '
        Me.lvwChannelUsers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwChannelUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwChannelUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colChannelUsers})
        Me.lvwChannelUsers.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwChannelUsers.FullRowSelect = True
        Me.lvwChannelUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvwChannelUsers.Location = New System.Drawing.Point(663, 27)
        Me.lvwChannelUsers.Name = "lvwChannelUsers"
        Me.lvwChannelUsers.Size = New System.Drawing.Size(161, 337)
        Me.lvwChannelUsers.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwChannelUsers.TabIndex = 78
        Me.lvwChannelUsers.UseCompatibleStateImageBehavior = False
        Me.lvwChannelUsers.View = System.Windows.Forms.View.Details
        '
        'colChannelUsers
        '
        Me.colChannelUsers.Text = "Nicks:"
        Me.colChannelUsers.Width = 140
        '
        'rtbChannelView
        '
        Me.rtbChannelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbChannelView.Location = New System.Drawing.Point(0, 27)
        Me.rtbChannelView.Name = "rtbChannelView"
        Me.rtbChannelView.ReadOnly = True
        Me.rtbChannelView.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.rtbChannelView.Size = New System.Drawing.Size(660, 337)
        Me.rtbChannelView.TabIndex = 79
        Me.rtbChannelView.Text = ""
        '
        'mnuMainMenu
        '
        Me.mnuMainMenu.BackColor = System.Drawing.Color.Transparent
        Me.mnuMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMainMenuFile, Me.mnuMainMenuConnect, Me.mnuMainMenuDisconnect, Me.mnuMainMenuOptions, Me.mnuMainMenuAbout})
        Me.mnuMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mnuMainMenu.Name = "mnuMainMenu"
        Me.mnuMainMenu.Size = New System.Drawing.Size(827, 24)
        Me.mnuMainMenu.TabIndex = 80
        Me.mnuMainMenu.Text = "MenuStripTrans1"
        '
        'mnuMainMenuFile
        '
        Me.mnuMainMenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMainMenuFileExit})
        Me.mnuMainMenuFile.Name = "mnuMainMenuFile"
        Me.mnuMainMenuFile.Size = New System.Drawing.Size(35, 20)
        Me.mnuMainMenuFile.Text = "File"
        '
        'mnuMainMenuFileExit
        '
        Me.mnuMainMenuFileExit.Name = "mnuMainMenuFileExit"
        Me.mnuMainMenuFileExit.Size = New System.Drawing.Size(103, 22)
        Me.mnuMainMenuFileExit.Text = "Exit"
        '
        'mnuMainMenuConnect
        '
        Me.mnuMainMenuConnect.Name = "mnuMainMenuConnect"
        Me.mnuMainMenuConnect.Size = New System.Drawing.Size(59, 20)
        Me.mnuMainMenuConnect.Text = "Connect"
        '
        'mnuMainMenuDisconnect
        '
        Me.mnuMainMenuDisconnect.Name = "mnuMainMenuDisconnect"
        Me.mnuMainMenuDisconnect.Size = New System.Drawing.Size(71, 20)
        Me.mnuMainMenuDisconnect.Text = "Disconnect"
        '
        'mnuMainMenuOptions
        '
        Me.mnuMainMenuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMainMenuOptionsrawData})
        Me.mnuMainMenuOptions.Name = "mnuMainMenuOptions"
        Me.mnuMainMenuOptions.Size = New System.Drawing.Size(56, 20)
        Me.mnuMainMenuOptions.Text = "Options"
        '
        'mnuMainMenuOptionsrawData
        '
        Me.mnuMainMenuOptionsrawData.CheckOnClick = True
        Me.mnuMainMenuOptionsrawData.Name = "mnuMainMenuOptionsrawData"
        Me.mnuMainMenuOptionsrawData.Size = New System.Drawing.Size(132, 22)
        Me.mnuMainMenuOptionsrawData.Text = "Raw Data"
        '
        'mnuMainMenuAbout
        '
        Me.mnuMainMenuAbout.Name = "mnuMainMenuAbout"
        Me.mnuMainMenuAbout.Size = New System.Drawing.Size(48, 20)
        Me.mnuMainMenuAbout.Text = "About"
        '
        'MainView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rtbChannelView)
        Me.Controls.Add(Me.lvwChannelUsers)
        Me.Controls.Add(Me.mnuMainMenu)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "MainView"
        Me.Size = New System.Drawing.Size(827, 367)
        Me.mnuMainMenu.ResumeLayout(False)
        Me.mnuMainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents lvwChannelUsers As System.Windows.Forms.ListView
    Private WithEvents colChannelUsers As System.Windows.Forms.ColumnHeader
    Public WithEvents rtbChannelView As System.Windows.Forms.RichTextBox
    Private WithEvents mnuMainMenuFile As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuMainMenuFileExit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuMainMenuConnect As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuMainMenuDisconnect As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuMainMenuAbout As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuMainMenuOptions As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuMainMenuOptionsrawData As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuMainMenu As FiSi1307_IRC_Client.MenuStripTrans

End Class
