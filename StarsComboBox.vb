Public Class StarsComboBox

#Region " Properties "
	Public Property Value() As String
		Get
			Return Me.txt.Text.Trim
		End Get
		Set(ByVal value As String)
			Me.txt.Text = value.Trim
		End Set
	End Property

	Public WriteOnly Property Items() As String()
		Set(ByVal value As String())
			Me.cbo.Items.Clear()
			Me.cbo.Items.AddRange(value)
		End Set
	End Property
#End Region

#Region " Handlers "
	Private Sub cbo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo.SelectionChangeCommitted
		Me.txt.Text &= If(Me.txt.Text.Trim = String.Empty, Me.cbo.SelectedItem, ", " & Me.cbo.SelectedItem)
	End Sub

	Private Sub StarsComboBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
		Me.cbo.Width = Me.Width
		Me.txt.Width = Me.cbo.Width - 26
	End Sub
#End Region

End Class
