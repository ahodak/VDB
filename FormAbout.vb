Public NotInheritable Class FormAbout

	Private Sub FormAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Initialize all of the text displayed on the About Box.
		' TODO: Customize the application's assembly information in the "Application" pane of the project 
		'    properties dialog (under the "Project" menu).
		Dim rm As New ResourceManager("VDB.Strings", GetType(FormMain).Assembly)

		lblProductName.Text = My.Application.Info.ProductName
		lblVersion.Text = String.Format("{0}: {1}", rm.GetString("Version"), My.Application.Info.Version.ToString)
		lblCopyright.Text = My.Application.Info.Copyright & ControlChars.CrLf & rm.GetString("Rights")
		lblCompanyName.Text = My.Application.Info.CompanyName
	End Sub

	Private Sub FormClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, lblCompanyName.Click, lblCopyright.Click, lblProductName.Click, lblUrl.Click, lblVersion.Click
		Me.Close()
	End Sub

End Class
