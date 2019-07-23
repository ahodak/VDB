Public Class SupportedLanguages
	Inherits List(Of SupportedLanguageInfo)

#Region " Constructor "
	Public Sub New()
		MyBase.New()

		Me.Add(New SupportedLanguageInfo)

		Dim dirs() As String = Directory.GetDirectories(My.Application.Info.DirectoryPath)

		For Each dir As String In dirs
			If File.Exists(dir & "\VDB.resources.dll") Then
				Try
					Dim objCulture As New CultureInfo(dir.Substring(dir.LastIndexOf("\") + 1))

					Me.Add(New SupportedLanguageInfo(objCulture.Name, objCulture.DisplayName))
				Catch

				End Try
			End If
		Next
	End Sub
#End Region

#Region " Properties "
	Default Public Overloads Property Item(ByVal name As String) As SupportedLanguageInfo
		Get
			Dim Result As SupportedLanguageInfo = Nothing

			For Each lang As SupportedLanguageInfo In Me
				If (String.Compare(lang.Name, name, True) = 0) Then
					Result = lang
				End If
			Next

			Return Result
		End Get
		Set(ByVal value As SupportedLanguageInfo)
			For Each lang As SupportedLanguageInfo In Me
				If (String.Compare(lang.Name, name, True) = 0) Then
					lang = value
				End If
			Next
		End Set
	End Property
#End Region

#Region " Methods "
	Public Function AsArray() As SupportedLanguageInfo()
		Dim Result(0) As SupportedLanguageInfo
		Result(0) = Nothing

		If (Me.Count > 0) Then
			Array.Resize(Result, Me.Count)

			For i As Integer = 0 To Me.Count - 1
				Result(i) = Me.Item(i)
			Next
		End If

		Return Result
	End Function

	Public Function Names() As String()
		Dim Result(0) As String
		Result(0) = String.Empty

		If (Me.Count > 0) Then
			Array.Resize(Result, Me.Count)

			For i As Integer = 0 To Me.Count - 1
				Result(i) = Me.Item(i).DisplayName
			Next
		End If

		Return Result
	End Function
#End Region

End Class

Public Class SupportedLanguageInfo

#Region " Members "
	Private _Name As String
	Private _DisplayName As String
#End Region

#Region " Constructors "
	Public Sub New()
		_Name = String.Empty
		_DisplayName = "English"
	End Sub

	Public Sub New(ByVal name As String, ByVal displayName As String)
		_Name = name
		_DisplayName = displayName
	End Sub
#End Region

#Region " Properties "
	Public Property Name() As String
		Get
			Return _Name
		End Get
		Set(ByVal value As String)
			_Name = value.Trim
		End Set
	End Property

	Public Property DisplayName() As String
		Get
			Return _DisplayName
		End Get
		Set(ByVal value As String)
			_DisplayName = value.Trim
		End Set
	End Property

	Public ReadOnly Property Culture() As CultureInfo
		Get
			Return New CultureInfo(_Name)
		End Get
	End Property
#End Region

End Class
