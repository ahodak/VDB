<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStat
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStat))
		Me.lblTotal1 = New System.Windows.Forms.Label
		Me.lblGiven1 = New System.Windows.Forms.Label
		Me.lblLength1 = New System.Windows.Forms.Label
		Me.lblSize1 = New System.Windows.Forms.Label
		Me.lblLongest1 = New System.Windows.Forms.Label
		Me.lblShortest1 = New System.Windows.Forms.Label
		Me.lblTotal = New System.Windows.Forms.Label
		Me.lblGiven = New System.Windows.Forms.Label
		Me.lblLength = New System.Windows.Forms.Label
		Me.lblSize = New System.Windows.Forms.Label
		Me.lblLongest = New System.Windows.Forms.Label
		Me.lblShortest = New System.Windows.Forms.Label
		Me.Label13 = New System.Windows.Forms.Label
		Me.cmdClose = New System.Windows.Forms.Button
		Me.SuspendLayout()
		'
		'lblTotal1
		'
		resources.ApplyResources(Me.lblTotal1, "lblTotal1")
		Me.lblTotal1.Name = "lblTotal1"
		'
		'lblGiven1
		'
		resources.ApplyResources(Me.lblGiven1, "lblGiven1")
		Me.lblGiven1.Name = "lblGiven1"
		'
		'lblLength1
		'
		resources.ApplyResources(Me.lblLength1, "lblLength1")
		Me.lblLength1.Name = "lblLength1"
		'
		'lblSize1
		'
		resources.ApplyResources(Me.lblSize1, "lblSize1")
		Me.lblSize1.Name = "lblSize1"
		'
		'lblLongest1
		'
		resources.ApplyResources(Me.lblLongest1, "lblLongest1")
		Me.lblLongest1.Name = "lblLongest1"
		'
		'lblShortest1
		'
		resources.ApplyResources(Me.lblShortest1, "lblShortest1")
		Me.lblShortest1.Name = "lblShortest1"
		'
		'lblTotal
		'
		resources.ApplyResources(Me.lblTotal, "lblTotal")
		Me.lblTotal.AutoEllipsis = True
		Me.lblTotal.Name = "lblTotal"
		'
		'lblGiven
		'
		resources.ApplyResources(Me.lblGiven, "lblGiven")
		Me.lblGiven.AutoEllipsis = True
		Me.lblGiven.Name = "lblGiven"
		'
		'lblLength
		'
		resources.ApplyResources(Me.lblLength, "lblLength")
		Me.lblLength.AutoEllipsis = True
		Me.lblLength.Name = "lblLength"
		'
		'lblSize
		'
		resources.ApplyResources(Me.lblSize, "lblSize")
		Me.lblSize.AutoEllipsis = True
		Me.lblSize.Name = "lblSize"
		'
		'lblLongest
		'
		resources.ApplyResources(Me.lblLongest, "lblLongest")
		Me.lblLongest.AutoEllipsis = True
		Me.lblLongest.Name = "lblLongest"
		'
		'lblShortest
		'
		resources.ApplyResources(Me.lblShortest, "lblShortest")
		Me.lblShortest.AutoEllipsis = True
		Me.lblShortest.Name = "lblShortest"
		'
		'Label13
		'
		resources.ApplyResources(Me.Label13, "Label13")
		Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label13.Name = "Label13"
		'
		'cmdClose
		'
		resources.ApplyResources(Me.cmdClose, "cmdClose")
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.UseVisualStyleBackColor = True
		'
		'FormStat
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.Label13)
		Me.Controls.Add(Me.lblShortest)
		Me.Controls.Add(Me.lblLongest)
		Me.Controls.Add(Me.lblSize)
		Me.Controls.Add(Me.lblLength)
		Me.Controls.Add(Me.lblGiven)
		Me.Controls.Add(Me.lblTotal)
		Me.Controls.Add(Me.lblShortest1)
		Me.Controls.Add(Me.lblLongest1)
		Me.Controls.Add(Me.lblSize1)
		Me.Controls.Add(Me.lblLength1)
		Me.Controls.Add(Me.lblGiven1)
		Me.Controls.Add(Me.lblTotal1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FormStat"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lblTotal1 As System.Windows.Forms.Label
	Friend WithEvents lblGiven1 As System.Windows.Forms.Label
	Friend WithEvents lblLength1 As System.Windows.Forms.Label
	Friend WithEvents lblSize1 As System.Windows.Forms.Label
	Friend WithEvents lblLongest1 As System.Windows.Forms.Label
	Friend WithEvents lblShortest1 As System.Windows.Forms.Label
	Friend WithEvents lblTotal As System.Windows.Forms.Label
	Friend WithEvents lblGiven As System.Windows.Forms.Label
	Friend WithEvents lblLength As System.Windows.Forms.Label
	Friend WithEvents lblSize As System.Windows.Forms.Label
	Friend WithEvents lblLongest As System.Windows.Forms.Label
	Friend WithEvents lblShortest As System.Windows.Forms.Label
	Friend WithEvents Label13 As System.Windows.Forms.Label
	Friend WithEvents cmdClose As System.Windows.Forms.Button
End Class
