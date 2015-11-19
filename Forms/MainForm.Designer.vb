<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.PanelUserControlHolder = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'PanelUserControlHolder
        '
        Me.PanelUserControlHolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelUserControlHolder.Location = New System.Drawing.Point(0, 0)
        Me.PanelUserControlHolder.Name = "PanelUserControlHolder"
        Me.PanelUserControlHolder.Size = New System.Drawing.Size(829, 369)
        Me.PanelUserControlHolder.TabIndex = 1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 369)
        Me.Controls.Add(Me.PanelUserControlHolder)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FiSi1307 IRC Client"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents PanelUserControlHolder As System.Windows.Forms.Panel

End Class
