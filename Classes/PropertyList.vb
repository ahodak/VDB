Imports System.Collections.Generic
Imports System.Collections.Specialized

<Serializable()> _
Public Class PropertyList
	Inherits IPersistable(Of PropertyList.Data)

#Region " Members "
	Private _FileName As String
#End Region

#Region " Constructors "
	''' <summary>
	''' Load File from data folder
	''' </summary>
	Public Sub New(ByVal fileName As String)
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
#End Region

#Region " Methods "
	''' <summary>
	''' Adding a new Entry to the Data
	''' </summary>
	''' <param name="name">Disk type description</param>
	Public Sub AddEntry(ByVal name As String)
		Dim entry As New Data.Entry

		entry.Name = name

		_data.Entries.Add(entry)
	End Sub

	''' <summary>
	''' Returns file name of the Logfile
	''' </summary>
	''' <returns>string containting path to sidebar data file</returns>
	Protected Overrides Function GetDataFilename() As String
		Return _FileName
	End Function

	Public Function AsArray() As String()
		Dim Result(0) As String
		Result(0) = String.Empty

		If (Me.Entries.Count > 0) Then
			Array.Resize(Result, Me.Entries.Count)

			For i As Integer = 0 To Me.Entries.Count - 1
				Result(i) = Me.Entries(i).Name
			Next
		End If

		Return Result
	End Function

	Public Function Contains(ByVal name As String) As Boolean
		Dim Result As Boolean = False

		For Each item As Data.Entry In _data.Entries
			If (item.Name = name) Then
				Result = True
				Exit For
			End If
		Next

		Return Result
	End Function
#End Region

#Region " Inner Classes "
	''' <summary>
	''' Data-Class for the TypeList
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
			Public Name As String
#End Region

#Region " Constructors "
			Public Sub New()
				Name = String.Empty
			End Sub
#End Region

		End Class
#End Region

	End Class
#End Region

End Class
