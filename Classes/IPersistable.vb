Imports System
Imports System.Web
Imports System.IO
Imports System.Xml.Serialization

Public MustInherit Class IPersistable(Of T)

#Region " Members "
	Private _path As String
	Protected _data As T
#End Region

#Region " Constructors "
	''' <summary>
	''' Creates a instance of Persistable. Also creates a instance of T
	''' </summary>
	Public Sub New()
		_data = CType(Activator.CreateInstance(GetType(T)), T)
	End Sub
#End Region

#Region " Methods "
	''' <summary>
	''' Loads the data from the filesystem. For deserialization a XmlSeralizer is used.
	''' </summary>
	Protected Sub LoadData()
		_path = GetDataFilename()

		'if the given path does not exist yet, create it
		If (Not Directory.Exists(Path.GetDirectoryName(_path))) Then
			Directory.CreateDirectory(Path.GetDirectoryName(_path))
		End If
		If (Not File.Exists(_path)) Then
			File.Create(_path)
		End If

		SyncLock _path
			' first check, if the object is maybe already in the cache
			Dim o As Object = Nothing
			Dim reader As FileStream = Nothing

			Try
				reader = File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
				Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))

				_data = CType(serializer.Deserialize(reader), T)
			Finally
				If (reader IsNot Nothing) Then reader.Dispose()
			End Try
		End SyncLock
	End Sub

	''' <summary>
	''' Persists the data back to the filesystem
	''' </summary>
	Public Sub SaveData()
		_path = GetDataFilename()

		SyncLock _path
			'if the given path does not exist yet, create it
			If (Not Directory.Exists(Path.GetDirectoryName(_path))) Then
				Directory.CreateDirectory(Path.GetDirectoryName(_path))
			End If

			'serialize and store the data to the filesystem
			Dim writer As FileStream = Nothing
			Try
				writer = File.Create(_path)
				Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))

				serializer.Serialize(writer, _data)
			Finally
				If (writer IsNot Nothing) Then writer.Dispose()
			End Try
		End SyncLock
	End Sub

	''' <summary>
	''' Deletes the data from the cache and filesystem
	''' </summary>
	Public Overridable Function Delete() As Boolean
		Dim Result As Boolean = True

		If (File.Exists(_path)) Then
			SyncLock _path
				Try
					File.Delete(_path)
				Catch
					Result = False
				End Try
			End SyncLock
		End If

		Return Result
	End Function

	Protected MustOverride Function GetDataFilename() As String

#End Region

End Class