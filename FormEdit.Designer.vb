<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEdit
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEdit))
		Me.lblType = New System.Windows.Forms.Label
		Me.txtNameRus = New System.Windows.Forms.TextBox
		Me.lblNameRus = New System.Windows.Forms.Label
		Me.lblNameEng = New System.Windows.Forms.Label
		Me.lblGenre = New System.Windows.Forms.Label
		Me.lblCompany = New System.Windows.Forms.Label
		Me.lblYear = New System.Windows.Forms.Label
		Me.lblDirector = New System.Windows.Forms.Label
		Me.lblStars = New System.Windows.Forms.Label
		Me.lblLength = New System.Windows.Forms.Label
		Me.lblSize = New System.Windows.Forms.Label
		Me.lblDescription = New System.Windows.Forms.Label
		Me.lblDate = New System.Windows.Forms.Label
		Me.cboType = New System.Windows.Forms.ComboBox
		Me.txtNameEng = New System.Windows.Forms.TextBox
		Me.cboGenre = New System.Windows.Forms.ComboBox
		Me.cmdGenre = New System.Windows.Forms.Button
		Me.cboCompany = New System.Windows.Forms.ComboBox
		Me.cmdCompany = New System.Windows.Forms.Button
		Me.txtYear = New System.Windows.Forms.NumericUpDown
		Me.cboDirector = New System.Windows.Forms.ComboBox
		Me.cmdDirector = New System.Windows.Forms.Button
		Me.ctrlStars = New VDB.StarsComboBox
		Me.cmdStars = New System.Windows.Forms.Button
		Me.calLength = New System.Windows.Forms.DateTimePicker
		Me.txtSize = New System.Windows.Forms.NumericUpDown
		Me.txtDescription = New System.Windows.Forms.TextBox
		Me.calDate = New System.Windows.Forms.DateTimePicker
		Me.cmdOk = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.lblSep = New System.Windows.Forms.Label
		Me.cmdType = New System.Windows.Forms.Button
		Me.lblRank = New System.Windows.Forms.Label
		Me.lblRank1 = New System.Windows.Forms.Label
		Me.lblRank2 = New System.Windows.Forms.Label
		Me.lblRank3 = New System.Windows.Forms.Label
		Me.lblRank4 = New System.Windows.Forms.Label
		Me.lblRank5 = New System.Windows.Forms.Label
		CType(Me.txtYear, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtSize, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'lblType
		'
		Me.lblType.AccessibleDescription = Nothing
		Me.lblType.AccessibleName = Nothing
		resources.ApplyResources(Me.lblType, "lblType")
		Me.lblType.Font = Nothing
		Me.lblType.Name = "lblType"
		'
		'txtNameRus
		'
		Me.txtNameRus.AccessibleDescription = Nothing
		Me.txtNameRus.AccessibleName = Nothing
		resources.ApplyResources(Me.txtNameRus, "txtNameRus")
		Me.txtNameRus.BackgroundImage = Nothing
		Me.txtNameRus.Font = Nothing
		Me.txtNameRus.Name = "txtNameRus"
		'
		'lblNameRus
		'
		Me.lblNameRus.AccessibleDescription = Nothing
		Me.lblNameRus.AccessibleName = Nothing
		resources.ApplyResources(Me.lblNameRus, "lblNameRus")
		Me.lblNameRus.Font = Nothing
		Me.lblNameRus.Name = "lblNameRus"
		'
		'lblNameEng
		'
		Me.lblNameEng.AccessibleDescription = Nothing
		Me.lblNameEng.AccessibleName = Nothing
		resources.ApplyResources(Me.lblNameEng, "lblNameEng")
		Me.lblNameEng.Font = Nothing
		Me.lblNameEng.Name = "lblNameEng"
		'
		'lblGenre
		'
		Me.lblGenre.AccessibleDescription = Nothing
		Me.lblGenre.AccessibleName = Nothing
		resources.ApplyResources(Me.lblGenre, "lblGenre")
		Me.lblGenre.Font = Nothing
		Me.lblGenre.Name = "lblGenre"
		'
		'lblCompany
		'
		Me.lblCompany.AccessibleDescription = Nothing
		Me.lblCompany.AccessibleName = Nothing
		resources.ApplyResources(Me.lblCompany, "lblCompany")
		Me.lblCompany.Font = Nothing
		Me.lblCompany.Name = "lblCompany"
		'
		'lblYear
		'
		Me.lblYear.AccessibleDescription = Nothing
		Me.lblYear.AccessibleName = Nothing
		resources.ApplyResources(Me.lblYear, "lblYear")
		Me.lblYear.Font = Nothing
		Me.lblYear.Name = "lblYear"
		'
		'lblDirector
		'
		Me.lblDirector.AccessibleDescription = Nothing
		Me.lblDirector.AccessibleName = Nothing
		resources.ApplyResources(Me.lblDirector, "lblDirector")
		Me.lblDirector.Font = Nothing
		Me.lblDirector.Name = "lblDirector"
		'
		'lblStars
		'
		Me.lblStars.AccessibleDescription = Nothing
		Me.lblStars.AccessibleName = Nothing
		resources.ApplyResources(Me.lblStars, "lblStars")
		Me.lblStars.Font = Nothing
		Me.lblStars.Name = "lblStars"
		'
		'lblLength
		'
		Me.lblLength.AccessibleDescription = Nothing
		Me.lblLength.AccessibleName = Nothing
		resources.ApplyResources(Me.lblLength, "lblLength")
		Me.lblLength.Font = Nothing
		Me.lblLength.Name = "lblLength"
		'
		'lblSize
		'
		Me.lblSize.AccessibleDescription = Nothing
		Me.lblSize.AccessibleName = Nothing
		resources.ApplyResources(Me.lblSize, "lblSize")
		Me.lblSize.Font = Nothing
		Me.lblSize.Name = "lblSize"
		'
		'lblDescription
		'
		Me.lblDescription.AccessibleDescription = Nothing
		Me.lblDescription.AccessibleName = Nothing
		resources.ApplyResources(Me.lblDescription, "lblDescription")
		Me.lblDescription.Font = Nothing
		Me.lblDescription.Name = "lblDescription"
		'
		'lblDate
		'
		Me.lblDate.AccessibleDescription = Nothing
		Me.lblDate.AccessibleName = Nothing
		resources.ApplyResources(Me.lblDate, "lblDate")
		Me.lblDate.Font = Nothing
		Me.lblDate.Name = "lblDate"
		'
		'cboType
		'
		Me.cboType.AccessibleDescription = Nothing
		Me.cboType.AccessibleName = Nothing
		resources.ApplyResources(Me.cboType, "cboType")
		Me.cboType.BackgroundImage = Nothing
		Me.cboType.Font = Nothing
		Me.cboType.FormattingEnabled = True
		Me.cboType.Name = "cboType"
		Me.cboType.Sorted = True
		'
		'txtNameEng
		'
		Me.txtNameEng.AccessibleDescription = Nothing
		Me.txtNameEng.AccessibleName = Nothing
		resources.ApplyResources(Me.txtNameEng, "txtNameEng")
		Me.txtNameEng.BackgroundImage = Nothing
		Me.txtNameEng.Font = Nothing
		Me.txtNameEng.Name = "txtNameEng"
		'
		'cboGenre
		'
		Me.cboGenre.AccessibleDescription = Nothing
		Me.cboGenre.AccessibleName = Nothing
		resources.ApplyResources(Me.cboGenre, "cboGenre")
		Me.cboGenre.BackgroundImage = Nothing
		Me.cboGenre.Font = Nothing
		Me.cboGenre.FormattingEnabled = True
		Me.cboGenre.Name = "cboGenre"
		Me.cboGenre.Sorted = True
		'
		'cmdGenre
		'
		Me.cmdGenre.AccessibleDescription = Nothing
		Me.cmdGenre.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdGenre, "cmdGenre")
		Me.cmdGenre.BackgroundImage = Nothing
		Me.cmdGenre.Font = Nothing
		Me.cmdGenre.Name = "cmdGenre"
		Me.cmdGenre.UseVisualStyleBackColor = True
		'
		'cboCompany
		'
		Me.cboCompany.AccessibleDescription = Nothing
		Me.cboCompany.AccessibleName = Nothing
		resources.ApplyResources(Me.cboCompany, "cboCompany")
		Me.cboCompany.BackgroundImage = Nothing
		Me.cboCompany.Font = Nothing
		Me.cboCompany.FormattingEnabled = True
		Me.cboCompany.Name = "cboCompany"
		Me.cboCompany.Sorted = True
		'
		'cmdCompany
		'
		Me.cmdCompany.AccessibleDescription = Nothing
		Me.cmdCompany.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdCompany, "cmdCompany")
		Me.cmdCompany.BackgroundImage = Nothing
		Me.cmdCompany.Font = Nothing
		Me.cmdCompany.Name = "cmdCompany"
		Me.cmdCompany.UseVisualStyleBackColor = True
		'
		'txtYear
		'
		Me.txtYear.AccessibleDescription = Nothing
		Me.txtYear.AccessibleName = Nothing
		resources.ApplyResources(Me.txtYear, "txtYear")
		Me.txtYear.Font = Nothing
		Me.txtYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
		Me.txtYear.Name = "txtYear"
		'
		'cboDirector
		'
		Me.cboDirector.AccessibleDescription = Nothing
		Me.cboDirector.AccessibleName = Nothing
		resources.ApplyResources(Me.cboDirector, "cboDirector")
		Me.cboDirector.BackgroundImage = Nothing
		Me.cboDirector.Font = Nothing
		Me.cboDirector.FormattingEnabled = True
		Me.cboDirector.Name = "cboDirector"
		Me.cboDirector.Sorted = True
		'
		'cmdDirector
		'
		Me.cmdDirector.AccessibleDescription = Nothing
		Me.cmdDirector.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdDirector, "cmdDirector")
		Me.cmdDirector.BackgroundImage = Nothing
		Me.cmdDirector.Font = Nothing
		Me.cmdDirector.Name = "cmdDirector"
		Me.cmdDirector.UseVisualStyleBackColor = True
		'
		'ctrlStars
		'
		Me.ctrlStars.AccessibleDescription = Nothing
		Me.ctrlStars.AccessibleName = Nothing
		resources.ApplyResources(Me.ctrlStars, "ctrlStars")
		Me.ctrlStars.BackgroundImage = Nothing
		Me.ctrlStars.Font = Nothing
		Me.ctrlStars.Name = "ctrlStars"
		Me.ctrlStars.Value = ""
		'
		'cmdStars
		'
		Me.cmdStars.AccessibleDescription = Nothing
		Me.cmdStars.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdStars, "cmdStars")
		Me.cmdStars.BackgroundImage = Nothing
		Me.cmdStars.Font = Nothing
		Me.cmdStars.Name = "cmdStars"
		Me.cmdStars.UseVisualStyleBackColor = True
		'
		'calLength
		'
		Me.calLength.AccessibleDescription = Nothing
		Me.calLength.AccessibleName = Nothing
		resources.ApplyResources(Me.calLength, "calLength")
		Me.calLength.BackgroundImage = Nothing
		Me.calLength.CalendarFont = Nothing
		Me.calLength.CustomFormat = Nothing
		Me.calLength.Font = Nothing
		Me.calLength.Format = System.Windows.Forms.DateTimePickerFormat.Time
		Me.calLength.Name = "calLength"
		Me.calLength.ShowUpDown = True
		Me.calLength.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
		'
		'txtSize
		'
		Me.txtSize.AccessibleDescription = Nothing
		Me.txtSize.AccessibleName = Nothing
		resources.ApplyResources(Me.txtSize, "txtSize")
		Me.txtSize.Font = Nothing
		Me.txtSize.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
		Me.txtSize.Name = "txtSize"
		'
		'txtDescription
		'
		Me.txtDescription.AcceptsReturn = True
		Me.txtDescription.AcceptsTab = True
		Me.txtDescription.AccessibleDescription = Nothing
		Me.txtDescription.AccessibleName = Nothing
		resources.ApplyResources(Me.txtDescription, "txtDescription")
		Me.txtDescription.BackgroundImage = Nothing
		Me.txtDescription.Font = Nothing
		Me.txtDescription.Name = "txtDescription"
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
		'cmdType
		'
		Me.cmdType.AccessibleDescription = Nothing
		Me.cmdType.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdType, "cmdType")
		Me.cmdType.BackgroundImage = Nothing
		Me.cmdType.Font = Nothing
		Me.cmdType.Name = "cmdType"
		Me.cmdType.UseVisualStyleBackColor = True
		'
		'lblRank
		'
		Me.lblRank.AccessibleDescription = Nothing
		Me.lblRank.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRank, "lblRank")
		Me.lblRank.Font = Nothing
		Me.lblRank.Name = "lblRank"
		'
		'lblRank1
		'
		Me.lblRank1.AccessibleDescription = Nothing
		Me.lblRank1.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRank1, "lblRank1")
		Me.lblRank1.ForeColor = System.Drawing.Color.Silver
		Me.lblRank1.Name = "lblRank1"
		Me.lblRank1.UseCompatibleTextRendering = True
		'
		'lblRank2
		'
		Me.lblRank2.AccessibleDescription = Nothing
		Me.lblRank2.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRank2, "lblRank2")
		Me.lblRank2.ForeColor = System.Drawing.Color.Silver
		Me.lblRank2.Name = "lblRank2"
		Me.lblRank2.UseCompatibleTextRendering = True
		'
		'lblRank3
		'
		Me.lblRank3.AccessibleDescription = Nothing
		Me.lblRank3.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRank3, "lblRank3")
		Me.lblRank3.ForeColor = System.Drawing.Color.Silver
		Me.lblRank3.Name = "lblRank3"
		Me.lblRank3.UseCompatibleTextRendering = True
		'
		'lblRank4
		'
		Me.lblRank4.AccessibleDescription = Nothing
		Me.lblRank4.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRank4, "lblRank4")
		Me.lblRank4.ForeColor = System.Drawing.Color.Silver
		Me.lblRank4.Name = "lblRank4"
		Me.lblRank4.UseCompatibleTextRendering = True
		'
		'lblRank5
		'
		Me.lblRank5.AccessibleDescription = Nothing
		Me.lblRank5.AccessibleName = Nothing
		resources.ApplyResources(Me.lblRank5, "lblRank5")
		Me.lblRank5.ForeColor = System.Drawing.Color.Silver
		Me.lblRank5.Name = "lblRank5"
		Me.lblRank5.UseCompatibleTextRendering = True
		'
		'FormEdit
		'
		Me.AcceptButton = Me.cmdOk
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.CancelButton = Me.cmdCancel
		Me.Controls.Add(Me.lblRank5)
		Me.Controls.Add(Me.lblRank4)
		Me.Controls.Add(Me.lblRank3)
		Me.Controls.Add(Me.lblRank2)
		Me.Controls.Add(Me.lblRank1)
		Me.Controls.Add(Me.lblRank)
		Me.Controls.Add(Me.lblSep)
		Me.Controls.Add(Me.cmdCancel)
		Me.Controls.Add(Me.cmdOk)
		Me.Controls.Add(Me.calDate)
		Me.Controls.Add(Me.txtDescription)
		Me.Controls.Add(Me.txtSize)
		Me.Controls.Add(Me.calLength)
		Me.Controls.Add(Me.txtYear)
		Me.Controls.Add(Me.cmdCompany)
		Me.Controls.Add(Me.cmdStars)
		Me.Controls.Add(Me.cmdDirector)
		Me.Controls.Add(Me.cmdType)
		Me.Controls.Add(Me.cmdGenre)
		Me.Controls.Add(Me.cboCompany)
		Me.Controls.Add(Me.ctrlStars)
		Me.Controls.Add(Me.cboDirector)
		Me.Controls.Add(Me.cboGenre)
		Me.Controls.Add(Me.cboType)
		Me.Controls.Add(Me.lblDate)
		Me.Controls.Add(Me.lblDescription)
		Me.Controls.Add(Me.lblSize)
		Me.Controls.Add(Me.lblLength)
		Me.Controls.Add(Me.lblStars)
		Me.Controls.Add(Me.lblDirector)
		Me.Controls.Add(Me.lblYear)
		Me.Controls.Add(Me.lblCompany)
		Me.Controls.Add(Me.lblGenre)
		Me.Controls.Add(Me.lblNameEng)
		Me.Controls.Add(Me.lblNameRus)
		Me.Controls.Add(Me.txtNameEng)
		Me.Controls.Add(Me.txtNameRus)
		Me.Controls.Add(Me.lblType)
		Me.Font = Nothing
		Me.Icon = Nothing
		Me.MinimizeBox = False
		Me.Name = "FormEdit"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		CType(Me.txtYear, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtSize, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lblType As System.Windows.Forms.Label
	Friend WithEvents txtNameRus As System.Windows.Forms.TextBox
	Friend WithEvents lblNameRus As System.Windows.Forms.Label
	Friend WithEvents lblNameEng As System.Windows.Forms.Label
	Friend WithEvents lblGenre As System.Windows.Forms.Label
	Friend WithEvents lblCompany As System.Windows.Forms.Label
	Friend WithEvents lblYear As System.Windows.Forms.Label
	Friend WithEvents lblDirector As System.Windows.Forms.Label
	Friend WithEvents lblStars As System.Windows.Forms.Label
	Friend WithEvents lblLength As System.Windows.Forms.Label
	Friend WithEvents lblSize As System.Windows.Forms.Label
	Friend WithEvents lblDescription As System.Windows.Forms.Label
	Friend WithEvents lblDate As System.Windows.Forms.Label
	Friend WithEvents cboType As System.Windows.Forms.ComboBox
	Friend WithEvents txtNameEng As System.Windows.Forms.TextBox
	Friend WithEvents cboGenre As System.Windows.Forms.ComboBox
	Friend WithEvents cmdGenre As System.Windows.Forms.Button
	Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
	Friend WithEvents cmdCompany As System.Windows.Forms.Button
	Friend WithEvents txtYear As System.Windows.Forms.NumericUpDown
	Friend WithEvents cboDirector As System.Windows.Forms.ComboBox
	Friend WithEvents cmdDirector As System.Windows.Forms.Button
	Friend WithEvents ctrlStars As StarsComboBox
	Friend WithEvents cmdStars As System.Windows.Forms.Button
	Friend WithEvents calLength As System.Windows.Forms.DateTimePicker
	Friend WithEvents txtSize As System.Windows.Forms.NumericUpDown
	Friend WithEvents txtDescription As System.Windows.Forms.TextBox
	Friend WithEvents calDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents cmdOk As System.Windows.Forms.Button
	Friend WithEvents cmdCancel As System.Windows.Forms.Button
	Friend WithEvents lblSep As System.Windows.Forms.Label
	Friend WithEvents cmdType As System.Windows.Forms.Button
	Friend WithEvents lblRank As System.Windows.Forms.Label
	Friend WithEvents lblRank1 As System.Windows.Forms.Label
	Friend WithEvents lblRank2 As System.Windows.Forms.Label
	Friend WithEvents lblRank3 As System.Windows.Forms.Label
	Friend WithEvents lblRank4 As System.Windows.Forms.Label
	Friend WithEvents lblRank5 As System.Windows.Forms.Label
End Class
