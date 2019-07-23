<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDebtors
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDebtors))
		Me.txt = New System.Windows.Forms.TextBox
		Me.SuspendLayout()
		'
		'txt
		'
		Me.txt.AccessibleDescription = Nothing
		Me.txt.AccessibleName = Nothing
		resources.ApplyResources(Me.txt, "txt")
		Me.txt.BackgroundImage = Nothing
		Me.txt.Font = Nothing
		Me.txt.Name = "txt"
		Me.txt.ReadOnly = True
		'
		'FormDebtors
		'
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.Controls.Add(Me.txt)
		Me.Font = Nothing
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = Nothing
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FormDebtors"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txt As System.Windows.Forms.TextBox
End Class
