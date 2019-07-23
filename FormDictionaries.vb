Public Class FormDictionaries

#Region " Members "
	Private rm As ResourceManager
	Private _Mode As FormDictionariesMode

	Public Genres As New PropertyList(My.Application.Info.DirectoryPath & "\data\genres.xml")
	Public Companies As New PropertyList(My.Application.Info.DirectoryPath & "\data\companies.xml")
	Public Directors As New PropertyList(My.Application.Info.DirectoryPath & "\data\directors.xml")
	Public Stars As New PropertyList(My.Application.Info.DirectoryPath & "\data\stars.xml")
	Public Types As New PropertyList(My.Application.Info.DirectoryPath & "\data\types.xml")
	Public Debtors As New PropertyList(My.Application.Info.DirectoryPath & "\data\debtors.xml")

	Private _IsGenresModified As Boolean
	Private _IsCompaniesModified As Boolean
	Private _IsDirectorsModified As Boolean
	Private _IsStarsModified As Boolean
	Private _IsTypesModified As Boolean
	Private _IsDebtorsModified As Boolean
#End Region

#Region " Constructor "
	Public Sub New()
		' This call is required by the Windows Form Designer.
		InitializeComponent()

		rm = New ResourceManager("VDB.Strings", GetType(FormMain).Assembly)
		_Mode = FormDictionariesMode.Select

		_IsGenresModified = False
		_IsCompaniesModified = False
		_IsDirectorsModified = False
		_IsStarsModified = False
		_IsTypesModified = False
		_IsDebtorsModified = False
	End Sub
#End Region

#Region " Properties "
	Public Property Mode() As FormDictionariesMode
		Get
			Return _Mode
		End Get
		Set(ByVal value As FormDictionariesMode)
			_Mode = value
		End Set
	End Property
#End Region

#Region " Handlers "
	Private Sub FormDictionaries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		lstGenre.Items.AddRange(Genres.AsArray)
		lstCompany.Items.AddRange(Companies.AsArray)
		lstDirector.Items.AddRange(Directors.AsArray)
		lstStar.Items.AddRange(Stars.AsArray)
		lstType.Items.AddRange(Types.AsArray)
		lstDebtor.Items.AddRange(Debtors.AsArray)

		If (My.Settings.WindowStateDictionaries <> FormWindowState.Minimized) Then Me.WindowState = My.Settings.WindowStateDictionaries
	End Sub

	Private Sub FormDictionaries_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		If (Me.WindowState <> FormWindowState.Minimized) Then My.Settings.WindowStateDictionaries = Me.WindowState
	End Sub

	Private Sub lstGenre_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstGenre.DoubleClick, lstCompany.DoubleClick, lstDirector.DoubleClick, lstStar.DoubleClick, lstType.DoubleClick, lstDebtor.DoubleClick
		If (_Mode = FormDictionariesMode.Select) Then
			cmdOk.PerformClick()
		Else
			cmdEdit.PerformClick()
		End If
	End Sub

	Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
		Select Case tab.SelectedIndex
			Case 0
				_IsGenresModified = _IsGenresModified Or AddItem(Genres, lstGenre, rm.GetString("IsGenresModified"))
			Case 1
				_IsCompaniesModified = _IsCompaniesModified Or AddItem(Companies, lstCompany, rm.GetString("IsCompaniesModified"))
			Case 2
				_IsDirectorsModified = _IsDirectorsModified Or AddItem(Directors, lstDirector, rm.GetString("IsDirectorsModified"))
			Case 3
				_IsStarsModified = _IsStarsModified Or AddItem(Stars, lstStar, rm.GetString("IsStarsModified"))
			Case 4
				_IsTypesModified = _IsTypesModified Or AddItem(Types, lstType, rm.GetString("IsTypesModified"))
			Case 5
				_IsDebtorsModified = _IsDebtorsModified Or AddItem(Debtors, lstDebtor, rm.GetString("IsDebtorsModified"))
		End Select
	End Sub

	Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
		Select Case tab.SelectedIndex
			Case 0
				_IsGenresModified = _IsGenresModified Or EditItem(Genres, lstGenre, rm.GetString("IsGenresModified"))
			Case 1
				_IsCompaniesModified = _IsCompaniesModified Or EditItem(Companies, lstCompany, rm.GetString("IsCompaniesModified"))
			Case 2
				_IsDirectorsModified = _IsDirectorsModified Or EditItem(Directors, lstDirector, rm.GetString("IsDirectorsModified"))
			Case 3
				_IsStarsModified = _IsStarsModified Or EditItem(Stars, lstStar, rm.GetString("IsStarsModified"))
			Case 4
				_IsTypesModified = _IsTypesModified Or EditItem(Types, lstType, rm.GetString("IsTypesModified"))
			Case 5
				_IsDebtorsModified = _IsDebtorsModified Or EditItem(Debtors, lstDebtor, rm.GetString("IsDebtorsModified"))
		End Select
	End Sub

	Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
		Select Case tab.SelectedIndex
			Case 0
				_IsGenresModified = _IsGenresModified Or DeleteItem(Genres, lstGenre)
			Case 1
				_IsCompaniesModified = _IsCompaniesModified Or DeleteItem(Companies, lstCompany)
			Case 2
				_IsDirectorsModified = _IsDirectorsModified Or DeleteItem(Directors, lstDirector)
			Case 3
				_IsStarsModified = _IsStarsModified Or DeleteItem(Stars, lstStar)
			Case 4
				_IsTypesModified = _IsTypesModified Or DeleteItem(Types, lstType)
			Case 5
				_IsDebtorsModified = _IsDebtorsModified Or DeleteItem(Debtors, lstDebtor)
		End Select
	End Sub

	Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
		If _IsGenresModified Then Genres.SaveData()
		If _IsCompaniesModified Then Companies.SaveData()
		If _IsDirectorsModified Then Directors.SaveData()
		If _IsStarsModified Then Stars.SaveData()
		If _IsTypesModified Then Types.SaveData()
		If _IsDebtorsModified Then Debtors.SaveData()

		Me.Close()
	End Sub

	Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
#End Region

#Region " Methods "
	Private Function AddItem(ByRef obj As PropertyList, ByRef ctrl As ListBox, ByVal request As String) As Boolean
		Dim Result As Boolean = False
		Dim sValue As String = InputBox(request, rm.GetString("Add"))

		If (Not String.IsNullOrEmpty(sValue)) Then
			If (Not obj.Contains(sValue)) Then
				obj.AddEntry(sValue)

				ctrl.Items.Clear()
				ctrl.Items.AddRange(obj.AsArray)
			End If

			ctrl.SelectedIndex = ctrl.FindString(sValue)

			Result = True
		End If

		Return Result
	End Function

	Private Function EditItem(ByRef obj As PropertyList, ByRef ctrl As ListBox, ByVal request As String) As Boolean
		Dim Result As Boolean = False

		If (ctrl.SelectedIndex >= 0) Then
			Dim sValue As String = InputBox(request, rm.GetString("Edit"), ctrl.SelectedItem.ToString)

			If (Not ctrl.SelectedItem.ToString.Equals(sValue, StringComparison.InvariantCultureIgnoreCase)) Then
				If (Not String.IsNullOrEmpty(sValue)) Then
					If (Not obj.Contains(sValue)) Then
						obj.Entries(ctrl.SelectedIndex).Name = sValue

						ctrl.Items(ctrl.SelectedIndex) = sValue

						Result = True
					Else
						ctrl.SelectedIndex = ctrl.FindString(sValue)
					End If
				End If
			End If
		End If

		Return Result
	End Function

	Private Function DeleteItem(ByRef obj As PropertyList, ByRef ctrl As ListBox) As Boolean
		Dim Result As Boolean = False

		If (ctrl.SelectedIndex >= 0) Then
			If (MsgBox(rm.GetString("DeleteRequest"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, rm.GetString("Delete")) = MsgBoxResult.Yes) Then
				obj.Entries.RemoveAt(ctrl.SelectedIndex)
				ctrl.Items.RemoveAt(ctrl.SelectedIndex)

				If (ctrl.Items.Count > 0) Then ctrl.SelectedIndex = 0

				Result = True
			End If
		End If

		Return Result
	End Function
#End Region

End Class