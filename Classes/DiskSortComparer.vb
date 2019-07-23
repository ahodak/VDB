Public Class DiskComparer
	Implements IComparer(Of DiskList.Data.Entry)

#Region " Members "
	Private _SortOrder As String
#End Region

#Region " Properties "
	Public Property SortOrder() As String
		Get
			Return _SortOrder
		End Get
		Set(ByVal value As String)
			_SortOrder = value.Trim
		End Set
	End Property
#End Region

#Region " Methods "
	Public Function Compare(ByVal x As DiskList.Data.Entry, ByVal y As DiskList.Data.Entry) As Integer Implements IComparer(Of DiskList.Data.Entry).Compare
		If (x Is Nothing) Then
			If (y Is Nothing) Then
				' If x is Nothing and y is Nothing, they're
				' equal. 
				Return 0
			Else
				' If x is Nothing and y is not Nothing, y
				' is greater. 
				Return -1
			End If
		Else
			' If x is not Nothing...
			'
			If (y Is Nothing) Then
				' ...and y is Nothing, x is greater.
				Return 1
			Else
				' ...and y is not Nothing, compare the object based on SortOrder property value
				Dim Result As Integer = 0

				Select Case _SortOrder
					Case "Type"
						Result = String.Compare(x.Type, y.Type)
					Case "NameRus"
						Result = String.Compare(x.NameRus, y.NameRus)
					Case "NameEng"
						Result = String.Compare(x.NameEng, y.NameEng)
					Case "Genre"
						Result = String.Compare(x.Genre, y.Genre)
					Case "Company"
						Result = String.Compare(x.Company, y.Company)
					Case "Year"
						Result = IntegerCompare(x.Year, y.Year)
					Case "Director"
						Result = String.Compare(x.Director, y.Director)
					Case "Stars"
						Result = String.Compare(x.Stars, y.Stars)
					Case "Length"
						Result = IntegerCompare(x.Length, y.Length)
					Case "Size"
						Result = IntegerCompare(x.Size, y.Size)
					Case "Rank"
						Result = IntegerCompare(x.Rank, y.Rank)
					Case "Date"
						Result = Date.Compare(x.Date, y.Date)
					Case Else
						Throw New Exception("Invalid SortOrder property value")
				End Select

				If (Result = 0) Then Result = String.Compare(x.NameRus, y.NameRus)

				Return Result
			End If
		End If
	End Function

	Private Function IntegerCompare(ByVal x As Long, ByVal y As Long) As Integer
		Dim Result As Integer = 0

		If (x = y) Then
			Result = 0
		ElseIf (x < y) Then
			Result = -1
		Else
			Result = 1
		End If

		Return Result
	End Function
#End Region

End Class
