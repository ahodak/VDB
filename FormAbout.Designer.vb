<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAbout
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAbout))
		Me.lblProductName = New System.Windows.Forms.Label
		Me.lblVersion = New System.Windows.Forms.Label
		Me.lblCopyright = New System.Windows.Forms.Label
		Me.lblCompanyName = New System.Windows.Forms.Label
		Me.lblUrl = New System.Windows.Forms.Label
		Me.SuspendLayout()
		'
		'lblProductName
		'
		resources.ApplyResources(Me.lblProductName, "lblProductName")
		Me.lblProductName.BackColor = System.Drawing.Color.Transparent
		Me.lblProductName.Name = "lblProductName"
		'
		'lblVersion
		'
		resources.ApplyResources(Me.lblVersion, "lblVersion")
		Me.lblVersion.BackColor = System.Drawing.Color.Transparent
		Me.lblVersion.ForeColor = System.Drawing.Color.CornflowerBlue
		Me.lblVersion.Name = "lblVersion"
		'
		'lblCopyright
		'
		Me.lblCopyright.BackColor = System.Drawing.Color.Transparent
		resources.ApplyResources(Me.lblCopyright, "lblCopyright")
		Me.lblCopyright.Name = "lblCopyright"
		'
		'lblCompanyName
		'
		resources.ApplyResources(Me.lblCompanyName, "lblCompanyName")
		Me.lblCompanyName.BackColor = System.Drawing.Color.Transparent
		Me.lblCompanyName.Name = "lblCompanyName"
		'
		'lblUrl
		'
		resources.ApplyResources(Me.lblUrl, "lblUrl")
		Me.lblUrl.BackColor = System.Drawing.Color.Transparent
		Me.lblUrl.Name = "lblUrl"
		'
		'FormAbout
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.BackgroundImage = Global.VDB.My.Resources.Resources.AboutBG
		Me.Controls.Add(Me.lblUrl)
		Me.Controls.Add(Me.lblCompanyName)
		Me.Controls.Add(Me.lblCopyright)
		Me.Controls.Add(Me.lblVersion)
		Me.Controls.Add(Me.lblProductName)
		Me.DoubleBuffered = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FormAbout"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lblProductName As System.Windows.Forms.Label
	Friend WithEvents lblVersion As System.Windows.Forms.Label
	Friend WithEvents lblCopyright As System.Windows.Forms.Label
	Friend WithEvents lblCompanyName As System.Windows.Forms.Label
	Friend WithEvents lblUrl As System.Windows.Forms.Label

End Class
