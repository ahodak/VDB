<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGive
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGive))
		Me.lblDebtors = New System.Windows.Forms.Label
		Me.lstDebtors = New System.Windows.Forms.ListBox
		Me.lblDate = New System.Windows.Forms.Label
		Me.calDate = New System.Windows.Forms.DateTimePicker
		Me.cmdOk = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.lblSep = New System.Windows.Forms.Label
		Me.SuspendLayout()
		'
		'lblDebtors
		'
		Me.lblDebtors.AccessibleDescription = Nothing
		Me.lblDebtors.AccessibleName = Nothing
		resources.ApplyResources(Me.lblDebtors, "lblDebtors")
		Me.lblDebtors.Font = Nothing
		Me.lblDebtors.Name = "lblDebtors"
		'
		'lstDebtors
		'
		Me.lstDebtors.AccessibleDescription = Nothing
		Me.lstDebtors.AccessibleName = Nothing
		resources.ApplyResources(Me.lstDebtors, "lstDebtors")
		Me.lstDebtors.BackgroundImage = Nothing
		Me.lstDebtors.Font = Nothing
		Me.lstDebtors.FormattingEnabled = True
		Me.lstDebtors.Name = "lstDebtors"
		Me.lstDebtors.Sorted = True
		'
		'lblDate
		'
		Me.lblDate.AccessibleDescription = Nothing
		Me.lblDate.AccessibleName = Nothing
		resources.ApplyResources(Me.lblDate, "lblDate")
		Me.lblDate.Font = Nothing
		Me.lblDate.Name = "lblDate"
		'
		'calDate
		'
		Me.calDate.AccessibleDescription = Nothing
		Me.calDate.AccessibleName = Nothing
		resources.ApplyResources(Me.calDate, "calDate")
		Me.calDate.BackgroundImage = Nothing
		Me.calDate.CalendarFont = Nothing
		Me.calDate.CustomFormat = Nothing
		Me.calDate.Font = Nothing
		Me.calDate.Name = "calDate"
		'
		'cmdOk
		'
		Me.cmdOk.AccessibleDescription = Nothing
		Me.cmdOk.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdOk, "cmdOk")
		Me.cmdOk.BackgroundImage = Nothing
		Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.cmdOk.Font = Nothing
		Me.cmdOk.Name = "cmdOk"
		Me.cmdOk.UseVisualStyleBackColor = True
		'
		'cmdCancel
		'
		Me.cmdCancel.AccessibleDescription = Nothing
		Me.cmdCancel.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdCancel, "cmdCancel")
		Me.cmdCancel.BackgroundImage = Nothing
		Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdCancel.Font = Nothing
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdCancel.UseVisualStyleBackColor = True
		'
		'lblSep
		'
		Me.lblSep.AccessibleDescription = Nothing
		Me.lblSep.AccessibleName = Nothing
		resources.ApplyResources(Me.lblSep, "lblSep")
		Me.lblSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblSep.Font = Nothing
		Me.lblSep.Name = "lblSep"
		'
		'FormGive
		'
		Me.AcceptButton = Me.cmdOk
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.CancelButton = Me.cmdCancel
		Me.Controls.Add(Me.lblSep)
		Me.Controls.Add(Me.cmdCancel)
		Me.Controls.Add(Me.cmdOk)
		Me.Controls.Add(Me.calDate)
		Me.Controls.Add(Me.lblDate)
		Me.Controls.Add(Me.lstDebtors)
		Me.Controls.Add(Me.lblDebtors)
		Me.Font = Nothing
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = Nothing
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FormGive"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lblDebtors As System.Windows.Forms.Label
	Friend WithEvents lstDebtors As System.Windows.Forms.ListBox
	Friend WithEvents lblDate As System.Windows.Forms.Label
	Friend WithEvents calDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents cmdOk As System.Windows.Forms.Button
	Friend WithEvents cmdCancel As System.Windows.Forms.Button
	Friend WithEvents lblSep As System.Windows.Forms.Label
End Class
