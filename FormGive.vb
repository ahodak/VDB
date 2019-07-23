Public Class FormGive

#Region " Constructor "
	Public Sub New()

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		Dim Debtors As New PropertyList(My.Application.Info.DirectoryPath & "\data\debtors.xml")

		lstDebtors.Items.AddRange(Debtors.AsArray)

		calDate.Value = Now.Date
	End Sub
#End Region

#Region " Properties "
	Public Property DebtorDate() As Date
		Get
			Return calDate.Value
		End Get
		Set(ByVal value As Date)
			If (value = Date.MinValue) Then
				calDate.Value = Now
			Else
				calDate.Value = value
			End If
		End Set
	End Property

	Public Property Debtor() As String
		Get
			Dim Result As String = String.Empty

			If (lstDebtors.SelectedIndex >= 0) Then
				Result = lstDebtors.SelectedItem.ToString
			End If

			Return Result
		End Get
		Set(ByVal value As String)
			lstDebtors.SelectedIndex = lstDebtors.FindStringExact(value)
		End Set
	End Property
#End Region

#Region " Handlers "
	Private Sub FormGive_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If ((lstDebtors.Items.Count > 0) And (lstDebtors.SelectedIndex = -1)) Then lstDebtors.SelectedIndex = 0
	End Sub

	Private Sub lstDebtors_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDebtors.DoubleClick
		cmdOk.PerformClick()
	End Sub
#End Region

End Class