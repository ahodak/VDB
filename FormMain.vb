Public Class FormMain

#Region " Members "
	Private rm As ResourceManager
	Private _SupportedLanguages As SupportedLanguages

	Private _Disks As DiskList

	Private _DataState As DataState

	Private _FindThat As DiskList.Data.Entry
	Private _FindResults As List(Of DiskList.Data.Entry)
	Private _FindIndex As Integer
#End Region

#Region " Properties "
	Public Property State() As DataState
		Get
			Return _DataState
		End Get
		Set(ByVal value As DataState)
			Dim bIsNotEmpty As Boolean = (_Disks.Entries.Count > 0)
			Dim bIsSelected As Boolean = (lst.SelectedIndex > -1)
			Dim bIsGiven As Boolean = (bIsSelected AndAlso (Not String.IsNullOrEmpty(_Disks.Entries(lst.SelectedIndex).Debtor)))

			If (value <> DataState.SelectionChanged) Then _DataState = value

			Select Case _DataState
				Case DataState.New
					miSave.Enabled = False
					tbSave.Enabled = miSave.Enabled
					miSaveAs.Enabled = False
					miStat.Enabled = False
					miPreview.Enabled = False
					miPrint.Enabled = False
					miEdit.Enabled = False
					tbEdit.Enabled = miEdit.Enabled
					miDelete.Enabled = False
					tbDelete.Enabled = miDelete.Enabled
					miFind.Enabled = False
					tbFind.Enabled = miFind.Enabled
					miFindNext.Enabled = False
					miGive.Enabled = False
					tbGive.Enabled = miGive.Enabled
					miReturn.Enabled = False
					tbReturn.Enabled = miReturn.Enabled
					miDebtors.Enabled = False
					miSort.Enabled = False
				Case DataState.Modified
					miSave.Enabled = True
					tbSave.Enabled = miSave.Enabled
					miSaveAs.Enabled = True
					miStat.Enabled = bIsNotEmpty
					miPreview.Enabled = bIsNotEmpty
					miPrint.Enabled = bIsNotEmpty
					miEdit.Enabled = bIsSelected
					tbEdit.Enabled = miEdit.Enabled
					miDelete.Enabled = bIsSelected
					tbDelete.Enabled = miDelete.Enabled
					miFind.Enabled = bIsNotEmpty
					tbFind.Enabled = miFind.Enabled
					miFindNext.Enabled = (_FindResults IsNot Nothing)
					miGive.Enabled = bIsSelected
					tbGive.Enabled = miGive.Enabled
					miReturn.Enabled = bIsGiven
					tbReturn.Enabled = miReturn.Enabled
					miDebtors.Enabled = bIsNotEmpty
					miSort.Enabled = bIsNotEmpty
				Case DataState.Saved
					miSave.Enabled = False
					tbSave.Enabled = miSave.Enabled
					miSaveAs.Enabled = True
					miStat.Enabled = bIsNotEmpty
					miPreview.Enabled = bIsNotEmpty
					miPrint.Enabled = bIsNotEmpty
					miEdit.Enabled = bIsSelected
					tbEdit.Enabled = miEdit.Enabled
					miDelete.Enabled = bIsSelected
					tbDelete.Enabled = miDelete.Enabled
					miFind.Enabled = bIsNotEmpty
					tbFind.Enabled = miFind.Enabled
					miFindNext.Enabled = (_FindResults IsNot Nothing)
					miGive.Enabled = bIsSelected
					tbGive.Enabled = miGive.Enabled
					miReturn.Enabled = bIsGiven
					tbReturn.Enabled = miReturn.Enabled
					miDebtors.Enabled = bIsNotEmpty
					miSort.Enabled = bIsNotEmpty
				Case DataState.SelectionChanged
					miEdit.Enabled = bIsSelected
					tbEdit.Enabled = miEdit.Enabled
					miDelete.Enabled = bIsSelected
					tbDelete.Enabled = miDelete.Enabled
					miFindNext.Enabled = (_FindResults IsNot Nothing)
					miGive.Enabled = bIsSelected
					tbGive.Enabled = miGive.Enabled
					miReturn.Enabled = bIsGiven
					tbReturn.Enabled = miReturn.Enabled
			End Select
		End Set
	End Property
#End Region

#Region " Constructor "
	Public Sub New()
		_SupportedLanguages = New SupportedLanguages

		Try
			Thread.CurrentThread.CurrentUICulture = _SupportedLanguages(My.Settings.Language).Culture
		Catch
			Thread.CurrentThread.CurrentUICulture = New CultureInfo(String.Empty)
		End Try

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		rm = New ResourceManager("VDB.Strings", GetType(FormMain).Assembly)

		_DataState = DataState.New

		_Disks = New DiskList()
		_FindThat = Nothing
		_FindResults = Nothing
		_FindIndex = -1
	End Sub
#End Region

#Region " Handlers "

#Region " Form Events "
	Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Me.Cursor = Cursors.WaitCursor

		CopyMenuTextToToolbar(miOpen, tbOpen)
		CopyMenuTextToToolbar(miSave, tbSave)
		CopyMenuTextToToolbar(miAdd, tbAdd)
		CopyMenuTextToToolbar(miEdit, tbEdit)
		CopyMenuTextToToolbar(miDelete, tbDelete)
		CopyMenuTextToToolbar(miFind, tbFind)
		CopyMenuTextToToolbar(miGive, tbGive)
		CopyMenuTextToToolbar(miReturn, tbReturn)

		dlgOpen.InitialDirectory = My.Application.Info.DirectoryPath & "\data\"
		dlgSave.InitialDirectory = dlgOpen.InitialDirectory

		With My.Settings
			dlgPageSetup.PageSettings.Margins.Left = IIf(.PrintMarginLeft >= 0, .PrintMarginLeft, 50)
			dlgPageSetup.PageSettings.Margins.Right = IIf(.PrintMarginRight >= 0, .PrintMarginRight, 50)
			dlgPageSetup.PageSettings.Margins.Top = IIf(.PrintMarginTop >= 0, .PrintMarginTop, 50)
			dlgPageSetup.PageSettings.Margins.Bottom = IIf(.PrintMarginBottom >= 0, .PrintMarginBottom, 100)

			dlgPageSetup.PageSettings.Landscape = True
		End With

		dlgPreview.FindForm.WindowState = FormWindowState.Maximized

		If System.IO.File.Exists(My.Settings.LastPath) Then
			_Disks.FileName = My.Settings.LastPath
			_Disks.LoadData()
		End If

		If (Not String.IsNullOrEmpty(My.Settings.SortOrder)) Then
			_Disks.SortOrder = My.Settings.SortOrder
		End If

		CheckSortMenuItem()

		RefreshList()

		DisplayTitle()
		Me.State = DataState.Saved

		cboSearch_Leave(Me, Nothing)

		If (My.Settings.WindowStateMain <> FormWindowState.Minimized) Then Me.WindowState = My.Settings.WindowStateMain

		' Сохраняем в папке с данными таблицу стилей
		Dim sXSLFileName As String = My.Application.Info.DirectoryPath & "\data\disks.xsl"
		If (Not System.IO.File.Exists(sXSLFileName)) Then
			Try
				Dim fs As System.IO.FileStream = System.IO.File.Create(sXSLFileName)
				Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes(My.Resources.disks)

				fs.Write(info, 0, info.Length)
				fs.Close()
			Catch

			End Try
		End If

		stlStatus.Text = rm.GetString("Ready")
		Me.Cursor = Cursors.Default
	End Sub

	Private Sub FormMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		If (Me.State = DataState.Modified) Then
			Dim Result As DialogResult = MsgBox(rm.GetString("SaveRequest"), MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, My.Application.Info.Title)

			Select Case Result
				Case Windows.Forms.DialogResult.Yes
					miSave.PerformClick()
				Case Windows.Forms.DialogResult.Cancel
					e.Cancel = True
			End Select
		End If

		My.Settings.SortOrder = _Disks.SortOrder
		If (Me.WindowState <> FormWindowState.Minimized) Then My.Settings.WindowStateMain = Me.WindowState
	End Sub
#End Region

#Region " Menu Events "
	Private Sub miNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNew.Click
		_Disks = New DiskList()

		RefreshList()

		DisplayTitle()
		Me.State = DataState.New
	End Sub

	Private Sub miOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miOpen.Click, tbOpen.Click
		dlgOpen.InitialDirectory = My.Application.Info.DirectoryPath

		If (dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK) Then
			Me.Cursor = Cursors.WaitCursor

			_Disks = New DiskList(dlgOpen.FileName)

			RefreshList()

			DisplayTitle()
			Me.State = DataState.Saved

			My.Settings.LastPath = _Disks.FileName
			Me.Cursor = Cursors.Default
		End If
	End Sub

	Private Sub miSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miSave.Click, tbSave.Click
		If (Not String.IsNullOrEmpty(_Disks.FileName)) Then
			Me.Cursor = Cursors.WaitCursor
			_Disks.SaveData()

			DisplayTitle()
			Me.State = DataState.Saved

			DisplayStatistic()

			My.Settings.LastPath = _Disks.FileName
			Me.Cursor = Cursors.Default
		Else
			miSaveAs_Click(Me, Nothing)
		End If
	End Sub

	Private Sub miSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSaveAs.Click
		dlgSave.InitialDirectory = My.Application.Info.DirectoryPath

		If (dlgSave.ShowDialog = Windows.Forms.DialogResult.OK) Then
			_Disks.FileName = dlgSave.FileName

			miSave_Click(Me, Nothing)
		End If
	End Sub

	Private Sub miPrintSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPageSetup.Click
		dlgPageSetup.ShowDialog()
	End Sub

	Private Sub miPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPreview.Click
		GenerateReport()

		dlgPreview.ShowDialog()
	End Sub

	Private Sub miPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPrint.Click
		GenerateReport()

		dlgPrint.ShowDialog()
	End Sub

	Private Sub miStat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miStat.Click
		Dim iLength As Long = 0
		Dim iSize As Long = 0
		Dim iMaxLength As Long = 0
		Dim sMaxLength As String = String.Empty
		Dim iMinLength As Long = TimeSpan.FromDays(1).Ticks
		Dim sMinLength As String = String.Empty

		Me.Cursor = Cursors.WaitCursor

		Using frm As New FormStat
			With frm
				.lblTotal.Text = _Disks.Entries.Count.ToString
				.lblGiven.Text = _Disks.Given.ToString

				For Each disk In _Disks.Entries
					iSize += disk.Size
					iLength += disk.Length

					If (disk.Length > 0) Then
						If (disk.Length > iMaxLength) Then
							iMaxLength = disk.Length
							sMaxLength = disk.NameRus
						End If
						If (disk.Length < iMinLength) Then
							iMinLength = disk.Length
							sMinLength = disk.NameRus
						End If
					End If
				Next

				Dim t As TimeSpan = TimeSpan.FromTicks(iLength)
				.lblLength.Text = String.Format("{0}{4} {1}{5} {2}{6} {3}{7}", t.Days, t.Hours, t.Minutes, t.Seconds, rm.GetString("Days"), rm.GetString("Houres"), rm.GetString("Minutes"), rm.GetString("Seconds"))
				.lblSize.Text = iSize.ToString
				.lblLongest.Text = String.Format("{0} ({1})", sMaxLength, TimeSpan.FromTicks(iMaxLength).ToString)
				.lblShortest.Text = String.Format("{0} ({1})", sMinLength, TimeSpan.FromTicks(iMinLength).ToString)

				Me.Cursor = Cursors.Default

				.ShowDialog()
			End With
		End Using
	End Sub

	Private Sub miExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miExit.Click
		Me.Close()
	End Sub

	Private Sub miAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAdd.Click, tbAdd.Click
		Using frm As New FormEdit
			With frm
				.Mode = FormEditMode.Add
				.Text = rm.GetString("FormAddTitle")
				.txtYear.Value = Now.Year
				.calLength.Value = .calLength.MinDate

				If (.ShowDialog() = Windows.Forms.DialogResult.OK) Then
					Dim dDate As Date = .calDate.Value
					If (dDate = .calDate.MinDate) Then dDate = Date.MinValue

					Me.Cursor = Cursors.WaitCursor

					_Disks.AddEntry( _
					 .cboType.Text, _
					 .txtNameRus.Text.Trim, _
					 .txtNameEng.Text.Trim, _
					 .cboGenre.Text, _
					 .cboCompany.Text, _
					 .txtYear.Value, _
					 .cboDirector.Text, _
					 .ctrlStars.Value, _
					 .calLength.Value.TimeOfDay.Ticks, _
					 .txtSize.Value, _
					 .txtDescription.Text, _
					 .Rank, _
					 dDate _
					  )

					RefreshList(.txtNameRus.Text.Trim)

					Me.State = DataState.Modified
					Me.Cursor = Cursors.Default
				End If
			End With
		End Using
	End Sub

	Private Sub miEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEdit.Click, tbEdit.Click
		Using frm As New FormEdit
			frm.Mode = FormEditMode.Edit
			frm.Text = rm.GetString("FormEditTitle")

			With _Disks.Entries(lst.SelectedIndex)
				frm.cboType.Text = .Type
				frm.txtNameRus.Text = .NameRus
				frm.txtNameEng.Text = .NameEng
				frm.cboGenre.Text = .Genre
				frm.cboCompany.Text = .Company
				frm.txtYear.Value = .Year
				frm.cboDirector.Text = .Director
				frm.ctrlStars.Value = .Stars
				frm.calLength.Value = frm.calLength.MinDate.AddTicks(.Length)
				frm.txtSize.Value = .Size
				frm.txtDescription.Text = .Description
				frm.Rank = .Rank
				If (.Date = Date.MinValue) Then
					frm.calDate.Value = frm.calDate.MinDate
				Else
					frm.calDate.Value = .Date
				End If
			End With

			If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
				With _Disks.Entries(lst.SelectedIndex)
					Dim dDate As Date = frm.calDate.Value
					If (dDate = frm.calDate.MinDate) Then dDate = Date.MinValue

					Dim bIsModified As Boolean = _
					  (.Type <> frm.cboType.Text) Or _
					  (.NameRus <> frm.txtNameRus.Text) Or _
					  (.NameEng <> frm.txtNameEng.Text) Or _
					  (.Genre <> frm.cboGenre.Text) Or _
					  (.Company <> frm.cboCompany.Text) Or _
					  (.Year <> frm.txtYear.Value) Or _
					  (.Director <> frm.cboDirector.Text) Or _
					  (.Stars <> frm.ctrlStars.Value) Or _
					  (.Length <> frm.calLength.Value.TimeOfDay.Ticks) Or _
					  (.Size <> frm.txtSize.Value) Or _
					  (.Description <> frm.txtDescription.Text) Or _
					  (.Rank <> frm.Rank) Or _
					  (.Date <> dDate)

					If bIsModified Then
						.Type = frm.cboType.Text
						.NameRus = frm.txtNameRus.Text
						.NameEng = frm.txtNameEng.Text
						.Genre = frm.cboGenre.Text
						.Company = frm.cboCompany.Text
						.Year = frm.txtYear.Value
						.Director = frm.cboDirector.Text
						.Stars = frm.ctrlStars.Value
						.Length = frm.calLength.Value.TimeOfDay.Ticks
						.Size = frm.txtSize.Value
						.Description = frm.txtDescription.Text
						.Rank = frm.Rank
						.Date = dDate

						Me.Cursor = Cursors.WaitCursor

						RefreshList(.NameRus)

						Me.State = DataState.Modified
						Me.Cursor = Cursors.Default
					End If
				End With
			End If
		End Using
	End Sub

	Private Sub miDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDelete.Click, tbDelete.Click
		If (lst.SelectedIndex >= 0) Then
			If (MsgBox(rm.GetString("DeleteRequest"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, rm.GetString("FormDeleteTitle")) = MsgBoxResult.Yes) Then
				_Disks.Entries.RemoveAt(lst.SelectedIndex)
				lst.Items.RemoveAt(lst.SelectedIndex)

				RefreshList()

				Me.State = DataState.Modified
			End If
		End If
	End Sub

	Private Sub miFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFind.Click, tbFind.Click
		Using frm As New FormEdit
			frm.Mode = FormEditMode.Find
			frm.Text = rm.GetString("FormFindTitle")
			frm.txtYear.Value = 0
			frm.calLength.Value = frm.calLength.MinDate
			frm.calDate.Value = frm.calDate.MinDate

			If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
				_FindThat = New DiskList.Data.Entry

				With _FindThat
					.Type = frm.cboType.Text
					.NameRus = frm.txtNameRus.Text
					.NameEng = frm.txtNameEng.Text
					.Genre = frm.cboGenre.Text
					.Company = frm.cboCompany.Text
					.Year = frm.txtYear.Value
					.Director = frm.cboDirector.Text
					.Stars = frm.ctrlStars.Value
					.Length = frm.calLength.Value.TimeOfDay.Ticks
					.Size = frm.txtSize.Value
					.Description = frm.txtDescription.Text
					.Rank = frm.Rank
					.Date = IIf(frm.calDate.Value = frm.calDate.MinDate, Date.MinValue, frm.calDate.Value)
				End With

				Me.Cursor = Cursors.WaitCursor

				_FindResults = _Disks.Entries.FindAll(AddressOf FindMatch)
				_FindIndex = -1

				Me.Cursor = Cursors.Default

				miFindNext_Click(Me, Nothing)
			End If
		End Using
	End Sub

	Private Sub miFindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFindNext.Click
		If ((_FindResults IsNot Nothing) AndAlso (_FindResults.Count > 0)) Then
			_FindIndex += 1

			If (_FindIndex <= _FindResults.Count - 1) Then
				lst.SelectedIndex = lst.FindStringExact(_FindResults(_FindIndex).NameRus)
			Else
				_FindIndex = 0
				lst.SelectedIndex = lst.FindStringExact(_FindResults(_FindIndex).NameRus)
			End If
		Else
			MsgBox(rm.GetString("NotFound"), MsgBoxStyle.Information, My.Application.Info.Title)
			_FindResults = Nothing
			_FindThat = Nothing
		End If

		Me.State = DataState.SelectionChanged
	End Sub

	Private Sub miGive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGive.Click, tbGive.Click
		Using frm As New FormGive
			With _Disks.Entries(lst.SelectedIndex)
				frm.Debtor = .Debtor
				frm.DebtorDate = .DebtorDate

				If (frm.ShowDialog = Windows.Forms.DialogResult.OK) Then
					If ((.Debtor <> frm.Debtor) Or (.DebtorDate <> frm.DebtorDate)) Then
						.Debtor = frm.Debtor
						.DebtorDate = frm.DebtorDate

						lst_SelectedIndexChanged(Me, Nothing)
						DisplayStatistic()

						Me.State = DataState.Modified
					End If
				End If
			End With
		End Using
	End Sub

	Private Sub miReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miReturn.Click, tbReturn.Click
		If (MsgBox(rm.GetString("ReturnRequest"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes) Then
			With _Disks.Entries(lst.SelectedIndex)
				.Debtor = String.Empty
				.DebtorDate = Date.MinValue
			End With

			lst_SelectedIndexChanged(Me, Nothing)
			DisplayStatistic()

			Me.State = DataState.Modified
		End If
	End Sub

	Private Sub miDebtors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDebtors.Click
		Using frm As New FormDebtors
			Dim Debtors = From disk As DiskList.Data.Entry _
			   In _Disks.Entries _
			   Where disk.Debtor <> String.Empty _
			   Order By disk.Debtor, disk.NameRus _
			   Group By Name = disk.Debtor _
			   Into DebtedDisks = Group, Count()

			If (Debtors.Count > 0) Then
				Me.Cursor = Cursors.WaitCursor

				For Each debtor In Debtors
					frm.txt.Text &= debtor.Name & ControlChars.CrLf

					For Each disk In debtor.DebtedDisks
						frm.txt.Text &= ControlChars.Tab & disk.DebtorDate.ToShortDateString & " - " & disk.NameRus & ControlChars.CrLf
					Next
				Next

				Me.Cursor = Cursors.Default
			Else
				frm.txt.Text = rm.GetString("NoGiven")
			End If

			frm.txt.Select(0, 0)

			frm.ShowDialog()
		End Using
	End Sub

	Private Sub miSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSortType.Click, miSortNameRus.Click, miSortNameEng.Click, miSortGenre.Click, miSortCompany.Click, miSortYear.Click, miSortDirector.Click, miSortStars.Click, miSortLength.Click, miSortSize.Click, miSortRank.Click, miSortDate.Click
		Dim item As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
		Dim sSelectedItem As String = String.Empty

		Me.Cursor = Cursors.WaitCursor

		If (lst.SelectedIndex >= 0) Then sSelectedItem = lst.SelectedItem

		_Disks.SortOrder = item.Name.Substring(6)
		_Disks.Sort()

		CheckSortMenuItem()

		RefreshList(sSelectedItem)

		Me.Cursor = Cursors.Default
	End Sub

	Private Sub miDictionaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDictionaries.Click
		Using frm As New FormDictionaries
			frm.Mode = FormDictionariesMode.Edit

			frm.ShowDialog()
		End Using
	End Sub

	Private Sub miOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miOptions.Click
		Using frm As New FormOptions
			frm.cboLanguage.Items.AddRange(_SupportedLanguages.Names)

			frm.cboLanguage.SelectedIndex = _SupportedLanguages.IndexOf(_SupportedLanguages(My.Settings.Language))

			If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
				My.Settings.Language = _SupportedLanguages(frm.cboLanguage.SelectedIndex).Name
			End If
		End Using
	End Sub

	Private Sub miAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAbout.Click
		Using frm As New FormAbout
			frm.ShowDialog()
		End Using
	End Sub
#End Region

#Region " List Events "
	Private Sub lst_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst.DoubleClick
		miEdit.PerformClick()
	End Sub

	Private Sub lst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst.SelectedIndexChanged
		If (lst.SelectedIndex > -1) Then
			With _Disks.Entries.Item(lst.SelectedIndex)
				lblNo.Text = (lst.SelectedIndex + 1).ToString
				lblType.Text = .Type
				lblName.Text = .NameRus
				lblGenre.Text = .Genre
				lblCompany.Text = .Company
				lblYear.Text = IIf((.Year > 0), .Year.ToString, String.Empty)
				lblDirector.Text = .Director
				lblStars.Text = .Stars
				lblLength.Text = IIf((.Length > 0), TimeSpan.FromTicks(.Length).ToString, String.Empty)
				lblSize.Text = IIf((.Size > 0), .Size.ToString, String.Empty)
				lblDescription.Text = .Description
				If (.Date <> Date.MinValue) Then
					lblDate.Text = .Date.ToShortDateString
				Else
					lblDate.Text = String.Empty
				End If
				lblRank.Text = New String("«"c, .Rank)

				grpDebtor.Visible = Not String.IsNullOrEmpty(.Debtor)
				If grpDebtor.Visible Then
					lblDebtorName.Text = .Debtor
					lblDebtorDate.Text = .DebtorDate.ToShortDateString
				End If
			End With
		End If

		Me.State = DataState.SelectionChanged
	End Sub
#End Region

#Region " Other Events "
	Private Sub grpDebtor_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grpDebtor.VisibleChanged
		If grpDebtor.Visible Then
			lblDescription.Height = grpDebtor.Top - 6 - lblDescription.Top
		Else
			lblDescription.Height = lblDate1.Top - 6 - lblDescription.Top
		End If
	End Sub

	Private Sub cboSearch_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearch.Enter
		If (cboSearch.Text = rm.GetString("Find")) Then
			cboSearch.Text = String.Empty
			cboSearch.ForeColor = SystemColors.WindowText
		End If
	End Sub

	Private Sub cboSearch_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearch.Leave
		If String.IsNullOrEmpty(cboSearch.Text) Then
			cboSearch.Text = rm.GetString("Find")
			cboSearch.ForeColor = SystemColors.GrayText
		End If
	End Sub

	Private Sub cboSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSearch.KeyUp
		Dim iIndex As Integer = lst.FindString(cboSearch.Text)

		If (lst.SelectedIndex <> iIndex) Then lst.SelectedIndex = lst.FindString(cboSearch.Text)
	End Sub

	Private Sub cboSearch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearch.LostFocus
		Dim sSearch As String = cboSearch.Text

		If (Not String.IsNullOrEmpty(sSearch)) Then
			If (Not cboSearch.Items.Contains(sSearch)) Then cboSearch.Items.Add(sSearch)
		End If
	End Sub
#End Region

#Region " StatusBar Events "
	Private Sub stlTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stlTotal.Click
		miStat.PerformClick()
	End Sub

	Private Sub stlOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stlOut.Click
		miDebtors.PerformClick()
	End Sub

	Private Sub menu_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNew.MouseEnter, miOpen.MouseEnter, miSave.MouseEnter, miSaveAs.MouseEnter, miPageSetup.MouseEnter, miPreview.MouseEnter, miPrint.MouseEnter, miStat.MouseEnter, miExit.MouseEnter, miAdd.MouseEnter, miEdit.MouseEnter, miDelete.MouseEnter, miFind.MouseEnter, miFindNext.MouseEnter, miGive.MouseEnter, miReturn.MouseEnter, miDebtors.MouseEnter, miSortType.MouseEnter, miSortNameRus.MouseEnter, miSortNameEng.MouseEnter, miSortGenre.MouseEnter, miSortCompany.MouseEnter, miSortYear.MouseEnter, miSortDirector.MouseEnter, miSortStars.MouseEnter, miSortLength.MouseEnter, miSortSize.MouseEnter, miSortRank.MouseEnter, miSortDate.MouseEnter, miDictionaries.MouseEnter, miOptions.MouseEnter, miAbout.MouseEnter
		stlStatus.Text = rm.GetString(CType(sender, ToolStripMenuItem).Name & "ToolTip")
	End Sub

	Private Sub menu_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNew.MouseLeave, miOpen.MouseLeave, miSave.MouseLeave, miSaveAs.MouseLeave, miPageSetup.MouseLeave, miPreview.MouseLeave, miPrint.MouseLeave, miStat.MouseLeave, miExit.MouseLeave, miAdd.MouseLeave, miEdit.MouseLeave, miDelete.MouseLeave, miFind.MouseLeave, miFindNext.MouseLeave, miGive.MouseLeave, miReturn.MouseLeave, miDebtors.MouseLeave, miSortType.MouseLeave, miSortNameRus.MouseLeave, miSortNameEng.MouseLeave, miSortGenre.MouseLeave, miSortCompany.MouseLeave, miSortYear.MouseLeave, miSortDirector.MouseLeave, miSortStars.MouseLeave, miSortLength.MouseLeave, miSortSize.MouseLeave, miSortRank.MouseLeave, miSortDate.MouseLeave, miDictionaries.MouseLeave, miOptions.MouseLeave, miAbout.MouseLeave
		stlStatus.Text = rm.GetString("Ready")
	End Sub
#End Region

#End Region

#Region " Private Methods "
	Private Sub CopyMenuTextToToolbar(ByRef menuItem As ToolStripMenuItem, ByRef toolbarButton As ToolStripButton)
		toolbarButton.Text = menuItem.Text.Replace("&", String.Empty).Replace(".", String.Empty)
	End Sub

	Private Sub CheckSortMenuItem()
		With _Disks
			miSortType.Checked = (.SortOrder = "Type")
			miSortNameRus.Checked = (.SortOrder = "NameRus")
			miSortNameEng.Checked = (.SortOrder = "NameEng")
			miSortGenre.Checked = (.SortOrder = "Genre")
			miSortCompany.Checked = (.SortOrder = "Company")
			miSortYear.Checked = (.SortOrder = "Year")
			miSortDirector.Checked = (.SortOrder = "Director")
			miSortStars.Checked = (.SortOrder = "Stars")
			miSortLength.Checked = (.SortOrder = "Length")
			miSortSize.Checked = (.SortOrder = "Size")
			miSortRank.Checked = (.SortOrder = "Rank")
			miSortDate.Checked = (.SortOrder = "Date")
		End With
	End Sub

	Private Sub RefreshList(Optional ByVal selectedValue As String = "")
		lst.Items.Clear()

		lblNo.Text = String.Empty
		lblType.Text = String.Empty
		lblName.Text = String.Empty
		lblGenre.Text = String.Empty
		lblCompany.Text = String.Empty
		lblYear.Text = String.Empty
		lblDirector.Text = String.Empty
		lblStars.Text = String.Empty
		lblLength.Text = String.Empty
		lblSize.Text = String.Empty
		lblDescription.Text = String.Empty
		lblDate.Text = String.Empty
		lblRank.Text = String.Empty
		grpDebtor.Visible = False

		If (_Disks.Entries.Count > 0) Then
			_Disks.Sort()

			For Each item As DiskList.Data.Entry In _Disks.Entries
				lst.Items.Add(item.NameRus)
			Next

			If (Not String.IsNullOrEmpty(selectedValue)) Then
				lst.SelectedIndex = lst.FindStringExact(selectedValue)
			Else
				lst.SelectedIndex = 0
			End If
		End If

		DisplayStatistic()
	End Sub

	Private Sub DisplayTitle()
		If (Not String.IsNullOrEmpty(_Disks.FileName)) Then
			Me.Text = String.Format("{0} - {1}", My.Application.Info.Title, _Disks.FileName)
		Else
			Me.Text = My.Application.Info.Title
		End If
	End Sub

	Private Sub DisplayStatistic()
		stlTotal.Text = String.Format("{0}: {1}", rm.GetString("Total"), _Disks.Entries.Count.ToString())
		stlOut.Text = String.Format("{0}: {1}", rm.GetString("Given"), _Disks.Given.ToString())
	End Sub

	Private Function FindMatch(ByVal entry As DiskList.Data.Entry) As Boolean
		Dim Result As Boolean = False

		With _FindThat
			If (Not String.IsNullOrEmpty(.Type)) Then Result = entry.Type.Contains(.Type)
			If (Not String.IsNullOrEmpty(.NameRus)) Then Result = entry.NameRus.Contains(.NameRus)
			If (Not String.IsNullOrEmpty(.NameEng)) Then Result = entry.NameEng.Contains(.NameEng)
			If (Not String.IsNullOrEmpty(.Genre)) Then Result = entry.Genre.Contains(.Genre)
			If (Not String.IsNullOrEmpty(.Company)) Then Result = entry.Company.Contains(.Company)
			If (.Year > 0) Then Result = (entry.Year = .Year)
			If (Not String.IsNullOrEmpty(.Director)) Then Result = entry.Director.Contains(.Director)
			If (Not String.IsNullOrEmpty(.Stars)) Then Result = entry.Stars.Contains(.Stars)
			If (.Length > 0) Then Result = (entry.Length = .Length)
			If (.Size > 0) Then Result = (entry.Size = .Size)
			If (Not String.IsNullOrEmpty(.Description)) Then Result = entry.Description.Contains(.Description)
			If (.Rank > 0) Then Result = (entry.Rank = .Rank)
			If (.Date <> Date.MinValue) Then Result = (entry.Date = .Date)
		End With

		Return Result
	End Function

	Private Sub GenerateReport()
		Dim colNameRus As New ColumnInformation("NameRus", 0, StringAlignment.Near)
		Dim colGenre As New ColumnInformation("Genre", 2, StringAlignment.Near)
		Dim colYear As New ColumnInformation("Year", 0.7, StringAlignment.Center)
		Dim colDirector As New ColumnInformation("Director", 2.5, StringAlignment.Near)
		Dim colLength As New ColumnInformation("Length", 1, StringAlignment.Center)
		Dim colSize As New ColumnInformation("Size", 1, StringAlignment.Center)

		colNameRus.HeaderText = rm.GetString("Name")
		colGenre.HeaderText = rm.GetString("Genre")
		colYear.HeaderText = rm.GetString("Year")
		colDirector.HeaderText = rm.GetString("Director")
		colLength.HeaderText = rm.GetString("Length")
		AddHandler colLength.FormatColumn, AddressOf FormatTimeColumn
		colSize.HeaderText = rm.GetString("Size")

		With rep
			.ClearColumns()
			.AddColumn(colNameRus)
			.AddColumn(colGenre)
			.AddColumn(colYear)
			.AddColumn(colDirector)
			.AddColumn(colLength)
			.AddColumn(colSize)
			.DataView = _Disks.Table.AsDataView
			.HeaderHeight = 0.5
			.FooterHeight = 0.3
			.DocumentName = My.Application.Info.Title
		End With
	End Sub

	Public Sub FormatTimeColumn(ByVal sender As Object, ByRef e As FormatColumnEventArgs)
		Dim incomingValue As TimeSpan
		Dim outgoingValue As String = String.Empty

		If (Not IsDBNull(e.OriginalValue)) Then
			incomingValue = New TimeSpan(e.OriginalValue)
			outgoingValue = incomingValue.ToString
		End If

		e.StringValue = outgoingValue
	End Sub
#End Region

End Class
