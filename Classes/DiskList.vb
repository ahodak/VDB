Imports System.Collections.Generic
Imports System.Collections.Specialized

<Serializable()> _
Public Class DiskList
	Inherits IPersistable(Of DiskList.Data)

#Region " Members "
	Private _FileName As String
	Private _SortOrder As String
#End Region

#Region " Constructors "
	Public Sub New()
		_FileName = String.Empty
		_SortOrder = "NameRus"
	End Sub

	''' <summary>
	''' Load File from data folder
	''' </summary>
	Public Sub New(ByVal fileName As String)
		Me.New()

		_FileName = fileName

		Try
			LoadData()
		Catch

		End Try
	End Sub
#End Region

#Region " Properties "
	''' <summary>
	''' List of all Entries in the file
	''' </summary>
	Public ReadOnly Property Entries() As List(Of Data.Entry)
		Get
			Return _data.Entries
		End Get
	End Property

	Public Property FileName() As String
		Get
			Return _FileName
		End Get
		Set(ByVal value As String)
			_FileName = value.Trim
		End Set
	End Property

	Public ReadOnly Property Given() As Long
		Get
			Dim Result As Long = 0

			For Each item As DiskList.Data.Entry In Me.Entries
				If (Not String.IsNullOrEmpty(item.Debtor)) Then
					Result += 1
				End If
			Next

			Return Result
		End Get
	End Property

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
	Public Overloads Sub LoadData()
		MyBase.LoadData()

		Sort()
	End Sub

	Public Overloads Sub SaveData()
		MyBase.SaveData()

		Dim doc As New XmlDocument
		Dim pi As XmlProcessingInstruction

		doc.Load(GetDataFilename)
		pi = doc.CreateProcessingInstruction("xml-stylesheet", "alternate='yes' type='text/xsl' href='disks.xsl'")
		doc.InsertAfter(pi, doc.FirstChild)

		doc.Save(GetDataFilename)
	End Sub

	''' <summary>
	''' Adding a new Entry to the Data
	''' </summary>
	''' <param name="type">Disk type</param>
	Public Sub AddEntry( _
	 ByVal type As String, _
	 ByVal nameRus As String, _
	 ByVal nameEng As String, _
	 ByVal genre As String, _
	 ByVal company As String, _
	 ByVal year As Integer, _
	 ByVal director As String, _
	 ByVal stars As String, _
	 ByVal length As Long, _
	 ByVal size As Long, _
	 ByVal description As String, _
	 ByVal rank As Integer, _
	 ByVal [date] As Date _
	)
		Dim entry As New Data.Entry

		With entry
			.Type = type
			.NameRus = nameRus
			.NameEng = nameEng
			.Genre = genre
			.Company = company
			.Year = year
			.Director = director
			.Stars = stars
			.Length = length
			.Size = size
			.Description = description
			.Rank = rank
			.Date = [date]
		End With

		_data.Entries.Add(entry)
	End Sub

	Public Sub Sort()
		Dim comparer As New DiskComparer
		comparer.SortOrder = _SortOrder

		_data.Entries.Sort(comparer)
	End Sub

	Public Function Table() As DataTable
		Dim Result As New DataTable

		Result.Columns.Add("Type", Type.GetType("System.String"))
		Result.Columns.Add("NameRus", Type.GetType("System.String"))
		Result.Columns.Add("NameEng", Type.GetType("System.String"))
		Result.Columns.Add("Genre", Type.GetType("System.String"))
		Result.Columns.Add("Company", Type.GetType("System.String"))
		Result.Columns.Add("Year", Type.GetType("System.Int32"))
		Result.Columns.Add("Director", Type.GetType("System.String"))
		Result.Columns.Add("Stars", Type.GetType("System.String"))
		Result.Columns.Add("Length", Type.GetType("System.Int64"))
		Result.Columns.Add("Size", Type.GetType("System.Int64"))
		Result.Columns.Add("Description", Type.GetType("System.String"))
		Result.Columns.Add("Rank", Type.GetType("System.Int32"))
		Result.Columns.Add("Date", Type.GetType("System.DateTime"))

		For Each entry As Data.Entry In _data.Entries
			Dim row As DataRow = Result.NewRow()

			With entry
				row("Type") = .Type
				row("NameRus") = .NameRus
				row("NameEng") = .NameEng
				row("Genre") = .Genre
				row("Company") = .Company
				row("Year") = .Year
				row("Director") = .Director
				row("Stars") = .Stars
				row("Length") = .Length
				row("Size") = .Size
				row("Description") = .Description
				row("Rank") = .Rank
				row("Date") = .Date
			End With

			Result.Rows.Add(row)
		Next

		Return Result
	End Function
	''' <summary>
	''' Returns file name of the Logfile
	''' </summary>
	''' <returns>string containting path to sidebar data file</returns>
	Protected Overrides Function GetDataFilename() As String
		Return _FileName
	End Function
#End Region

#Region " Inner Classes "
	''' <summary>
	''' Data-Class for the Disks
	''' </summary>
	Public Class Data

#Region " Members "
		Public Entries As List(Of Entry)
#End Region

#Region " Constructors "
		Public Sub New()
			Entries = New List(Of Entry)
		End Sub
#End Region

#Region " Inner Classes "
		Public Class Entry

#Region " Members "
			Public Type As String
			Public NameRus As String
			Public NameEng As String
			Public Genre As String
			Public Company As String
			Public Year As Integer
			Public Director As String
			Public Stars As String
			Public Length As Long
			Public Size As Long
			Private _Description As String
			Public Rank As Integer
			Public [Date] As Date
			Public Debtor As String
			Public DebtorDate As Date
#End Region

#Region " Constructors "
			Public Sub New()
				Type = String.Empty
				NameRus = String.Empty
				NameEng = String.Empty
				Genre = String.Empty
				Company = String.Empty
				Year = 0
				Director = String.Empty
				Stars = String.Empty
				Length = 0
				Size = 0
				_Description = String.Empty
				Rank = 0
				[Date] = Date.MinValue
				Debtor = String.Empty
				DebtorDate = Now
			End Sub
#End Region

#Region " Prperties "
			<Serialization.XmlElement("Description", GetType(String))> _
			Public Property Description() As String
				Get
					Return _Description.Replace(ControlChars.Lf, ControlChars.CrLf)
				End Get
				Set(ByVal value As String)
					_Description = value.Replace(ControlChars.CrLf, ControlChars.Lf)
				End Set
			End Property
#End Region

		End Class
#End Region

	End Class
#End Region

End Class
