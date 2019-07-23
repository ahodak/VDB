Public Class FormEdit

#Region " Members "
	Private rm As ResourceManager
	Private _Mode As FormEditMode
	Private _Rank As Integer
#End Region

#Region " Constructor "
	Public Sub New()
		' This call is required by the Windows Form Designer.
		InitializeComponent()

		rm = New ResourceManager("VDB.Strings", GetType(FormMain).Assembly)
		_Mode = FormEditMode.None
		_Rank = 0
	End Sub
#End Region

#Region " Properties "
	Public Property Rank() As Integer
		Get
			Return _Rank
		End Get
		Set(ByVal value As Integer)
			_Rank = value

			Select Case _Rank
				Case 1
					lblRank1.ForeColor = Color.Orange
					lblRank2.ForeColor = Color.Silver
					lblRank3.ForeColor = Color.Silver
					lblRank4.ForeColor = Color.Silver
					lblRank5.ForeColor = Color.Silver
				Case 2
					lblRank1.ForeColor = Color.Orange
					lblRank2.ForeColor = Color.Orange
					lblRank3.ForeColor = Color.Silver
					lblRank4.ForeColor = Color.Silver
					lblRank5.ForeColor = Color.Silver
				Case 3
					lblRank1.ForeColor = Color.Orange
					lblRank2.ForeColor = Color.Orange
					lblRank3.ForeColor = Color.Orange
					lblRank4.ForeColor = Color.Silver
					lblRank5.ForeColor = Color.Silver
				Case 4
					lblRank1.ForeColor = Color.Orange
					lblRank2.ForeColor = Color.Orange
					lblRank3.ForeColor = Color.Orange
					lblRank4.ForeColor = Color.Orange
					lblRank5.ForeColor = Color.Silver
				Case 5
					lblRank1.ForeColor = Color.Orange
					lblRank2.ForeColor = Color.Orange
					lblRank3.ForeColor = Color.Orange
					lblRank4.ForeColor = Color.Orange
					lblRank5.ForeColor = Color.Orange
				Case Else
					lblRank1.ForeColor = Color.Silver
					lblRank2.ForeColor = Color.Silver
					lblRank3.ForeColor = Color.Silver
					lblRank4.ForeColor = Color.Silver
					lblRank5.ForeColor = Color.Silver
			End Select
		End Set
	End Property

	Public Property Mode() As FormEditMode
		Get
			Return _Mode
		End Get
		Set(ByVal value As FormEditMode)
			_Mode = value
		End Set
	End Property
#End Region

#Region " Handlers "
	Private Sub FormEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim Types As New PropertyList(My.Application.Info.DirectoryPath & "\data\types.xml")
		Dim Genres As New PropertyList(My.Application.Info.DirectoryPath & "\data\genres.xml")
		Dim Companies As New PropertyList(My.Application.Info.DirectoryPath & "\data\companies.xml")
		Dim Directors As New PropertyList(My.Application.Info.DirectoryPath & "\data\directors.xml")
		Dim Stars As New PropertyList(My.Application.Info.DirectoryPath & "\data\stars.xml")

		cboType.Items.AddRange(Types.AsArray)
		cboGenre.Items.AddRange(Genres.AsArray)
		cboCompany.Items.AddRange(Companies.AsArray)
		cboDirector.Items.AddRange(Directors.AsArray)
		ctrlStars.Items = Stars.AsArray

		If (My.Settings.WindowStateEdit <> FormWindowState.Minimized) Then Me.WindowState = My.Settings.WindowStateEdit
	End Sub

	Private Sub FormEdit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		If (_Mode <> FormEditMode.Find) Then
			If (DialogResult = Windows.Forms.DialogResult.OK) Then
				If String.IsNullOrEmpty(cboType.Text) Then
					MsgBox(rm.GetString("ErrorTypeIsEmpty"), MsgBoxStyle.Exclamation, My.Application.Info.Title)
					e.Cancel = True
				End If

				If ((Not e.Cancel) And String.IsNullOrEmpty(txtNameRus.Text)) Then
					MsgBox(rm.GetString("ErrorNameIsEmpty"), MsgBoxStyle.Exclamation, My.Application.Info.Title)
					e.Cancel = True
				End If
			End If
		End If

		If (Me.WindowState <> FormWindowState.Minimized) Then My.Settings.WindowStateEdit = Me.WindowState
	End Sub

	Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
		cboType.Text = cboType.Text.Trim
		txtNameRus.Text = txtNameRus.Text.Trim
		txtNameEng.Text = txtNameEng.Text.Trim
		cboGenre.Text = cboGenre.Text.Trim
		cboCompany.Text = cboCompany.Text.Trim
		cboDirector.Text = cboDirector.Text.Trim
		txtDescription.Text = txtDescription.Text.Trim

		Me.Close()
	End Sub

	Private Sub cmdType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdType.Click
		Using frm As New FormDictionaries
			frm.tab.SelectTab(4)

			If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
				If (frm.lstType.SelectedIndex >= 0) Then
					cboType.Items.Clear()
					cboType.Items.AddRange(frm.Types.AsArray)
					cboType.SelectedIndex = frm.lstType.SelectedIndex
				End If
			End If
		End Using
	End Sub

	Private Sub cmdGenre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenre.Click
		Using frm As New FormDictionaries
			frm.tab.SelectTab(0)

			If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
				If (frm.lstGenre.SelectedIndex >= 0) Then
					cboGenre.Items.Clear()
					cboGenre.Items.AddRange(frm.Genres.AsArray)
					cboGenre.SelectedIndex = frm.lstGenre.SelectedIndex
				End If
			End If
		End Using
	End Sub

	Private Sub cmdCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompany.Click
		Using frm As New FormDictionaries
			frm.tab.SelectTab(1)

			If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
				If (frm.lstCompany.SelectedIndex >= 0) Then
					cboCompany.Items.Clear()
					cboCompany.Items.AddRange(frm.Companies.AsArray)
					cboCompany.SelectedIndex = frm.lstCompany.SelectedIndex
				End If
			End If
		End Using
	End Sub

	Private Sub cmdDirector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDirector.Click
		Using frm As New FormDictionaries
			frm.tab.SelectTab(2)

			If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
				If (frm.lstDirector.SelectedIndex >= 0) Then
					cboDirector.Items.Clear()
					cboDirector.Items.AddRange(frm.Directors.AsArray)
					cboDirector.SelectedIndex = frm.lstDirector.SelectedIndex
				End If
			End If
		End Using
	End Sub

	Private Sub cmdStars_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStars.Click
		Using frm As New FormDictionaries
			frm.tab.SelectTab(3)

			If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
				Dim sStars As String = String.Empty

				If (frm.lstStar.SelectedItems.Count > 0) Then
					For Each item As String In frm.lstStar.SelectedItems
						sStars &= item & ", "
					Next
					sStars = sStars.Substring(0, sStars.Length - 2)

					ctrlStars.Items = frm.Stars.AsArray
					If (Not String.IsNullOrEmpty(ctrlStars.Value)) Then
						ctrlStars.Value &= ", " & sStars
					Else
						ctrlStars.Value = sStars
					End If
				End If
			End If
		End Using
	End Sub

	Private Sub lblRank1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRank1.DoubleClick
		Me.Rank = 0
	End Sub

	Private Sub lblRank1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRank1.Click
		Me.Rank = 1
	End Sub

	Private Sub lblRank2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRank2.Click
		Me.Rank = 2
	End Sub

	Private Sub lblRank3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRank3.Click
		Me.Rank = 3
	End Sub

	Private Sub lblRank4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRank4.Click
		Me.Rank = 4
	End Sub

	Private Sub lblRank5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRank5.Click
		Me.Rank = 5
	End Sub
#End Region

End Class