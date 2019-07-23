<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOptions
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOptions))
		Me.lblLanguage = New System.Windows.Forms.Label
		Me.cboLanguage = New System.Windows.Forms.ComboBox
		Me.cmdOk = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.lblRestart = New System.Windows.Forms.Label
		Me.lblSep = New System.Windows.Forms.Label
		Me.SuspendLayout()
		'
		'lblLanguage
		'
		resources.ApplyResources(Me.lblLanguage, "lblLanguage")
		Me.lblLanguage.Name = "lblLanguage"
		'
		'cboLanguage
		'
		resources.ApplyResources(Me.cboLanguage, "cboLanguage")
		Me.cboLanguage.FormattingEnabled = True
		Me.cboLanguage.Name = "cboLanguage"
		'
		'cmdOk
		'
		resources.ApplyResources(Me.cmdOk, "cmdOk")
		Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.cmdOk.Name = "cmdOk"
		Me.cmdOk.UseVisualStyleBackColor = True
		'
		'cmdCancel
		'
		resources.ApplyResources(Me.cmdCancel, "cmdCancel")
		Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdCancel.UseVisualStyleBackColor = True
		'
		'lblRestart
		'
		resources.ApplyResources(Me.lblRestart, "lblRestart")
		Me.lblRestart.Name = "lblRestart"
		'
		'lblSep
		'
		resources.ApplyResources(Me.lblSep, "lblSep")
		Me.lblSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblSep.Name = "lblSep"
		'
		'FormOptions
		'
		Me.AcceptButton = Me.cmdOk
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.cmdCancel
		Me.Controls.Add(Me.lblSep)
		Me.Controls.Add(Me.lblRestart)
		Me.Controls.Add(Me.cmdCancel)
		Me.Controls.Add(Me.cmdOk)
		Me.Controls.Add(Me.cboLanguage)
		Me.Controls.Add(Me.lblLanguage)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Name = "FormOptions"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lblLanguage As System.Windows.Forms.Label
	Friend WithEvents cboLanguage As System.Windows.Forms.ComboBox
	Friend WithEvents cmdOk As System.Windows.Forms.Button
	Friend WithEvents cmdCancel As System.Windows.Forms.Button
	Friend WithEvents lblRestart As System.Windows.Forms.Label
	Friend WithEvents lblSep As System.Windows.Forms.Label
End Class
