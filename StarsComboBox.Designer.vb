﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StarsComboBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
		Me.cbo = New System.Windows.Forms.ComboBox
		Me.txt = New System.Windows.Forms.TextBox
		Me.SuspendLayout()
		'
		'cbo
		'
		Me.cbo.FormattingEnabled = True
		Me.cbo.Location = New System.Drawing.Point(0, 0)
		Me.cbo.MaxDropDownItems = 10
		Me.cbo.Name = "cbo"
		Me.cbo.Size = New System.Drawing.Size(121, 21)
		Me.cbo.Sorted = True
		Me.cbo.TabIndex = 0
		Me.cbo.TabStop = False
		'
		'txt
		'
		Me.txt.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txt.Location = New System.Drawing.Point(3, 3)
		Me.txt.Name = "txt"
		Me.txt.Size = New System.Drawing.Size(100, 13)
		Me.txt.TabIndex = 1
		'
		'StarsComboBox
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.txt)
		Me.Controls.Add(Me.cbo)
		Me.Name = "StarsComboBox"
		Me.Size = New System.Drawing.Size(121, 21)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents cbo As System.Windows.Forms.ComboBox
	Friend WithEvents txt As System.Windows.Forms.TextBox

End Class
