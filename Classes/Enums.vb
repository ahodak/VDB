Public Enum FileState
	None = 0
	[New]
	Exists
End Enum

Public Enum DataState
	None = 0
	[New] = 1
	Modified
	Saved
	SelectionChanged
End Enum

Public Enum FormEditMode
	None = 0
	Add
	Edit
	Find
End Enum

Public Enum FormDictionariesMode
	None = 0
	[Select]
	Edit
End Enum
