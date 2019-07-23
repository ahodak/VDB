'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'
'Date: June 2002
'Author: Duncan Mackenzie
'http://www.gotdotnet.com/Community/User/viewprofile.aspx?userid=00011A674C38C375
'
'Requires the release version of .NET Framework

Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.ComponentModel

Public Class TabularReport
	Inherits Printing.PrintDocument

	Private rm As ResourceManager

	Public Sub New()
		MyBase.New()

		rm = New ResourceManager("VDB.Strings", GetType(FormMain).Assembly)
	End Sub

#Region " Dimensions "
	Protected m_HeaderHeight As Single = 1
	Protected m_FooterHeight As Single = 1
	Protected m_MaxDetailRowHeight As Single = 1
	Protected m_MinDetailRowHeight As Single = 0.5

	'HeaderHeight Property
	'Used to define the size of the page header, in inches
	'The header will stop at or before this distance from the top margin of the page
	<Category("Appearance")> _
	Public Property HeaderHeight() As Single
		Get
			Return m_HeaderHeight
		End Get
		Set(ByVal Value As Single)
			m_HeaderHeight = Value
		End Set
	End Property

	'FooterHeight Property
	'Used to define the size of the page footer, in inches.
	'The footer will start at this distance from the bottom margin of the page
	<Category("Appearance")> _
	Public Property FooterHeight() As Single
		Get
			Return m_FooterHeight
		End Get
		Set(ByVal Value As Single)
			m_FooterHeight = Value
		End Set
	End Property

	'MaxDetailRowHeight Property
	'Used to determine the maximum size of a detail row
	'any larger and it will be clipped at this size, possibly losing information
	<Category("Appearance")> _
	Public Property MaxDetailRowHeight() As Single
		Get
			Return m_MaxDetailRowHeight
		End Get
		Set(ByVal Value As Single)
			m_MaxDetailRowHeight = Value
		End Set
	End Property

	'MinDetailRowHeight Property
	'Used to determine the minimum size of a detail row
	'Even if the row is smaller, it will add empty space before
	'the next row is printed
	<Category("Appearance")> _
	Public Property MinDetailRowHeight() As Single
		Get
			Return m_MinDetailRowHeight
		End Get
		Set(ByVal Value As Single)
			m_MinDetailRowHeight = Value
		End Set
	End Property
#End Region

#Region " Columns "
	Protected m_Columns As New ArrayList() 'internal storage

	'Add a column object to the list of columns
	'Each column object should be a new instance of ColumnInformation
	'You can pass a single instance into AddColumn more than once, but
	'you will just get the same column printed out multiple times.
	Public Function AddColumn(ByVal ci As ColumnInformation) As Integer
		Return m_Columns.Add(ci)
	End Function

	Public Sub RemoveColumn(ByVal index As Integer)
		m_Columns.RemoveAt(index)
	End Sub

	Public Function GetColumn(ByVal index As Integer) As ColumnInformation
		Return CType(m_Columns(index), ColumnInformation)
	End Function

	Public Function ColumnCount() As Integer
		Return m_Columns.Count
	End Function

	'Just FYI, printing a report with 0 columns is just fine... 
	' a little weird, but technically fine.
	Public Sub ClearColumns()
		m_Columns.Clear()
	End Sub
#End Region

#Region " Page Count and Row Position "
	'keep these around internally to track the current row and page.
	Protected currentPage As Integer
	Protected currentRow As Integer

	'Reset the row and page count
	Protected Overrides Sub OnBeginPrint(ByVal e As System.Drawing.Printing.PrintEventArgs)
		currentPage = 0
		currentRow = 0
	End Sub

	'interesting note: If you want footers/headers like "Page 1/4"
	'you will have a bit of trouble producing them

	'you could add a max-page variable,
	'and track the last page generated on the previous print, 
	'and then output that value as the page count on the next printing
	'this would only work accurately if you forced the user to preview before printing
#End Region

#Region " Data Source "
	'Most data-driven controls accept a variety of data sources,
	'not just DataView objects, but the code is slightly more complex
	'in that case. I didn't want to confuse the printing issue, but check out
	'my articles on Windows Forms Control Development
	'for more detail on data binding
	'http://msdn.microsoft.com/library/en-us/dndotnet/html/custcntrlsampover.asp

	Protected m_DataView As DataView

	<Category("Data")> _
	Public Property DataView() As DataView
		Get
			Return m_DataView
		End Get
		Set(ByVal Value As DataView)
			m_DataView = Value
		End Set
	End Property

	'Just a little function to abstract the code required to obtain a specific
	'field from your data source. If you switched to a more generic 
	'data source such as anything implementing IList, this function could be rewritten
	'allowing most of the rest of your code to stay untouched.
	Protected Function GetField(ByVal row As DataRowView, ByVal fieldName As String) As Object
		Dim obj As Object = Nothing

		If m_DataView IsNot Nothing Then
			obj = row(fieldName)
		End If

		Return obj
	End Function
#End Region

#Region " Default Fonts and Colors "
	Protected m_DefaultReportFont As Font = New Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point)
	Protected m_PageHeaderFont As Font
	Protected m_ColumnHeaderFont As Font
	Protected m_FooterFont As Font
	Protected m_DetailFont As Font
	Protected m_Padding As Single

	'See the description attribute for details on what each property is used for.
	<Category("Appearance"), _
	Description("Font used throughout report unless overriden by HeaderFont, FooterFont, DetailFont or a setting in the ColumnInformation instance for a specific Column")> _
	Public Property DefaultReportFont() As Font
		Get
			Return m_DefaultReportFont
		End Get
		Set(ByVal Value As Font)
			If Not Value Is Nothing Then
				m_DefaultReportFont = Value
			End If
		End Set
	End Property

	<Category("Appearance"), _
	Description("Font used For the page header")> _
	Public Property PageHeaderFont() As Font
		Get
			If m_PageHeaderFont Is Nothing Then
				Return m_DefaultReportFont
			Else
				Return m_PageHeaderFont
			End If
		End Get
		Set(ByVal Value As Font)
			m_PageHeaderFont = Value
		End Set
	End Property

	<Category("Appearance"), _
	Description("Font used For the column header")> _
	Public Property ColumnHeaderFont() As Font
		Get
			If m_ColumnHeaderFont Is Nothing Then
				Return m_DefaultReportFont
			Else
				Return m_ColumnHeaderFont
			End If
		End Get
		Set(ByVal Value As Font)
			m_ColumnHeaderFont = Value
		End Set
	End Property

	<Category("Appearance"), _
	Description("Font used for the page footer")> _
	Public Property FooterFont() As Font
		Get
			If m_FooterFont Is Nothing Then
				Return m_DefaultReportFont
			Else
				Return m_FooterFont
			End If
		End Get
		Set(ByVal Value As Font)
			m_FooterFont = Value
		End Set
	End Property

	<Category("Appearance"), _
	Description("Font used for items in the Detail Row unless overriden by Font setting in Column Information")> _
	Public Property DetailFont() As Font
		Get
			If m_DetailFont Is Nothing Then
				Return m_DefaultReportFont
			Else
				Return m_DetailFont
			End If
		End Get
		Set(ByVal Value As Font)
			m_DetailFont = Value
		End Set
	End Property

	<Category("Appearance"), _
	Description("Left and right columns interval")> _
	   Public Property Padding() As Single
		Get
			Return m_Padding
		End Get
		Set(ByVal Value As Single)
			m_Padding = Value
		End Set
	End Property

	Protected m_DefaultReportBrush As Brush = Brushes.Black
	Protected m_HeaderBrush As Brush
	Protected m_FooterBrush As Brush
	Protected m_DetailBrush As Brush

	'Browsable(False) prevents these properties from showing up in the Properties Window
	'If I had used Color instead of Brush, it would have a nice designer in the Properties Window,
	'but Brush is actually much more verstatile, allow you to use gradients, texture or hatches 
	'in addition to solid colors.
	<Browsable(False)> _
	Public Property DefaultReportBrush() As Brush
		Get
			Return m_DefaultReportBrush
		End Get
		Set(ByVal Value As Brush)
			If Not Value Is Nothing Then
				m_DefaultReportBrush = Value
			End If
		End Set
	End Property

	<Browsable(False)> _
	Public Property HeaderBrush() As Brush
		Get
			If m_HeaderBrush Is Nothing Then
				Return m_DefaultReportBrush
			Else
				Return m_HeaderBrush
			End If
		End Get
		Set(ByVal Value As Brush)
			m_HeaderBrush = Value
		End Set
	End Property

	<Browsable(False)> _
	Public Property FooterBrush() As Brush
		Get
			If m_FooterBrush Is Nothing Then
				Return m_DefaultReportBrush
			Else
				Return m_FooterBrush
			End If
		End Get
		Set(ByVal Value As Brush)
			m_FooterBrush = Value
		End Set
	End Property

	<Browsable(False)> _
	Public Property DetailBrush() As Brush
		Get
			If m_DetailBrush Is Nothing Then
				Return m_DefaultReportBrush
			Else
				Return m_DetailBrush
			End If
		End Get
		Set(ByVal Value As Brush)
			m_DetailBrush = Value
		End Set
	End Property
#End Region

#Region " Section Printing Routines "
	Protected Overridable Function PrintPageHeader(ByVal bounds As RectangleF, ByVal e As PrintPageEventArgs, ByVal sizeOnly As Boolean) As Single
		Dim g As Graphics = e.Graphics

		Dim headerText As String = Me.DocumentName
		Dim headerTextLayout As New RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height)

		Dim headerHeight As Single
		Dim headerStringFormat As New StringFormat(StringFormatFlags.LineLimit)

		headerStringFormat.Alignment = StringAlignment.Near
		headerStringFormat.Trimming = StringTrimming.EllipsisWord

		'get the height, critical to use all the same options as the eventual DrawString call
		headerHeight = _
		  g.MeasureString(headerText, Me.PageHeaderFont, headerTextLayout.Size, _
		   headerStringFormat, 0, 0).Height

		If Not sizeOnly Then 'do the actual drawing
			g.DrawString(headerText, _
			 Me.PageHeaderFont, _
			 Me.HeaderBrush, _
			 headerTextLayout, _
			 headerStringFormat)
		End If

		Return Math.Min(bounds.Height, headerHeight)
	End Function

	Protected Overridable Function PrintLine(ByVal bounds As RectangleF, ByVal e As PrintPageEventArgs, ByVal width As Single, ByVal sizeOnly As Boolean) As Single
		Dim g As Graphics = e.Graphics

		If (width = 0) Then width = 0.01

		bounds.Height = width

		If Not sizeOnly Then
			g.DrawLine(New Pen(Color.Black, width), _
			  bounds.X, _
			  bounds.Y, _
			  bounds.Right, _
			  bounds.Y)
		End If

		Return bounds.Height
	End Function

	Protected Overridable Function PrintPageFooter(ByVal bounds As RectangleF, ByVal e As PrintPageEventArgs, ByVal sizeOnly As Boolean) As Single
		Dim g As Graphics = e.Graphics

		Dim footerTextLeft As String = String.Format("{0} {1}", rm.GetString("Page"), currentPage)
		Dim footerTextLayoutLeft As New RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height)
		Dim footerTextRight As String = Now.ToString
		Dim footerTextLayoutRight As New RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height)

		Dim footerStringFormat As New StringFormat(StringFormatFlags.LineLimit)
		footerStringFormat.Alignment = StringAlignment.Center

		Dim footerTextRightWidth As Single = _
		   g.MeasureString(footerTextRight, _
		   FooterFont, footerTextLayoutRight.Size, _
		   footerStringFormat, 0, 0).Width

		footerTextLayoutRight.X = bounds.Width - footerTextRightWidth + (e.MarginBounds.Left / 100)

		If Not sizeOnly Then
			g.DrawString(footerTextLeft, FooterFont, FooterBrush, footerTextLayoutLeft)
			g.DrawString(footerTextRight, FooterFont, FooterBrush, footerTextLayoutRight)
		End If

		Return bounds.Height
	End Function

	Protected Overridable Function PrintHeaderRow(ByVal x As Single, ByVal y As Single, _
	  ByVal minHeight As Single, ByVal maxHeight As Single, ByVal width As Single, _
	  ByVal e As PrintPageEventArgs, ByVal sizeOnly As Boolean) As Single

		Dim g As Graphics = e.Graphics

		Dim headerText As String
		Dim headerTextLayout As New RectangleF(x, y, width, maxHeight)
		Dim headerHeight As Single
		Dim headerRowFont As Font

		Dim headerStringFormat As New StringFormat(StringFormatFlags.LineLimit)
		headerStringFormat.Trimming = StringTrimming.EllipsisCharacter

		Dim ci As ColumnInformation

		ColumnsWidth(width)

		For cols As Integer = 0 To Me.ColumnCount - 1
			'use the provided functions, 
			'instead of going after the internal ArrayList 
			'and the CType() work is taken care of for you.
			ci = Me.GetColumn(cols)

			'if a font is not specified, use the DetailFont property of the report class
			If ci.HeaderFont Is Nothing Then
				headerRowFont = Me.ColumnHeaderFont
			Else
				headerRowFont = ci.HeaderFont
			End If

			headerText = ci.HeaderText
			headerStringFormat.Alignment = ci.Alignment
			headerTextLayout.Width = ci.Width

			If headerTextLayout.X - x >= width Then
				'none of it will fit onto the page
				Exit For
			ElseIf (headerTextLayout.X + headerTextLayout.Width - x) > width Then
				'some of it won't fit onto the page
				headerTextLayout.Width = width - headerTextLayout.X - x
			End If

			headerHeight = _
			 Math.Max(g.MeasureString(headerText, _
			   headerRowFont, headerTextLayout.Size, _
			   headerStringFormat, 0, 0).Height, _
			   headerHeight)

			'hmm... no space between columns?
			'This code lines the columns up flush, 
			'but if you wished to add a space between 
			'them you would need to add it to X here, 
			'in the check above to determine if the column 
			'will fit, and in the corresponding parts 
			'of the next For loop.

			headerTextLayout.X += headerTextLayout.Width
		Next

		headerTextLayout.X = x
		headerTextLayout.Height = Math.Max(Math.Min(headerHeight, maxHeight), minHeight)

		If Not sizeOnly Then
			For cols As Integer = 0 To Me.ColumnCount - 1
				ci = Me.GetColumn(cols)

				If ci.HeaderFont Is Nothing Then
					headerRowFont = Me.ColumnHeaderFont
				Else
					headerRowFont = ci.HeaderFont
				End If

				headerText = ci.HeaderText
				headerStringFormat.Alignment = ci.Alignment
				headerTextLayout.Width = ci.Width

				If headerTextLayout.X - x >= width Then
					'none of it will fit onto the page
					Exit For
				ElseIf (headerTextLayout.X + headerTextLayout.Width - x) > width Then
					'some of it won't fit onto the page
					headerTextLayout.Width = width - headerTextLayout.X - x
				End If

				headerTextLayout.X += m_Padding
				headerTextLayout.Width -= m_Padding

				g.DrawString(headerText, _
				 headerRowFont, DetailBrush, _
				 headerTextLayout, headerStringFormat)

				headerTextLayout.X -= m_Padding
				headerTextLayout.Width += m_Padding

				headerTextLayout.X += headerTextLayout.Width
			Next

			headerTextLayout.X = x
			headerTextLayout.Y = y
			headerTextLayout.Height = headerHeight
			headerTextLayout.Width = width
		End If

		Return headerTextLayout.Height
	End Function

	Protected Overridable Function PrintDetailRow(ByVal x As Single, ByVal y As Single, _
	  ByVal minHeight As Single, ByVal maxHeight As Single, ByVal width As Single, _
	  ByVal e As PrintPageEventArgs, _
	  ByVal row As DataRowView, _
	  ByVal sizeOnly As Boolean) As Single

		Dim g As Graphics = e.Graphics

		Dim detailText As String
		Dim detailTextLayout As New RectangleF(x, y, width, maxHeight)
		Dim detailHeight As Single
		Dim detailRowFont As Font

		Dim detailStringFormat As New StringFormat(StringFormatFlags.LineLimit)
		detailStringFormat.Trimming = StringTrimming.EllipsisCharacter

		Dim ci As ColumnInformation

		ColumnsWidth(width)

		For cols As Integer = 0 To Me.ColumnCount - 1
			'use the provided functions, 
			'instead of going after the internal ArrayList 
			'and the CType() work is taken care of for you.
			ci = Me.GetColumn(cols)

			'if a font is not specified, use the DetailFont property of the report class
			If ci.DetailFont Is Nothing Then
				detailRowFont = Me.DetailFont
			Else
				detailRowFont = ci.DetailFont
			End If

			detailText = ci.GetString(Me.GetField(row, ci.Field))
			detailStringFormat.Alignment = ci.Alignment
			detailTextLayout.Width = ci.Width

			If detailTextLayout.X - x >= width Then
				'none of it will fit onto the page
				Exit For
			ElseIf (detailTextLayout.X + detailTextLayout.Width - x) > width Then
				'some of it won't fit onto the page
				detailTextLayout.Width = width - detailTextLayout.X - x
			End If

			detailHeight = _
			 Math.Max(g.MeasureString(detailText, _
			   detailRowFont, detailTextLayout.Size, _
			   detailStringFormat, 0, 0).Height, _
			   detailHeight)

			'hmm... no space between columns?
			'This code lines the columns up flush, 
			'but if you wished to add a space between 
			'them you would need to add it to X here, 
			'in the check above to determine if the column 
			'will fit, and in the corresponding parts 
			'of the next For loop.

			detailTextLayout.X += detailTextLayout.Width
		Next

		detailTextLayout.X = x
		detailTextLayout.Height = Math.Max(Math.Min(detailHeight, maxHeight), minHeight)

		If Not sizeOnly Then
			For cols As Integer = 0 To Me.ColumnCount - 1
				ci = Me.GetColumn(cols)

				If ci.DetailFont Is Nothing Then
					detailRowFont = Me.DetailFont
				Else
					detailRowFont = ci.DetailFont
				End If

				detailText = ci.GetString(Me.GetField(row, ci.Field))
				detailStringFormat.Alignment = ci.Alignment
				detailTextLayout.Width = ci.Width

				If detailTextLayout.X - x >= width Then
					'none of it will fit onto the page
					Exit For
				ElseIf (detailTextLayout.X + detailTextLayout.Width + (m_Padding * 2) - x) > width Then
					'some of it won't fit onto the page
					detailTextLayout.Width = width - detailTextLayout.X
				End If

				detailTextLayout.X += m_Padding
				detailTextLayout.Width -= m_Padding

				g.DrawString(detailText, _
				 detailRowFont, DetailBrush, _
				 detailTextLayout, detailStringFormat)

				detailTextLayout.X -= m_Padding
				detailTextLayout.Width += m_Padding

				detailTextLayout.X += detailTextLayout.Width
			Next
			detailTextLayout.X = x + m_Padding
			detailTextLayout.Y = y
			detailTextLayout.Height = detailHeight
			detailTextLayout.Width = width
		End If

		Return detailTextLayout.Height
	End Function

	Private Sub ColumnsWidth(ByVal width As Single)
		Dim ci As ColumnInformation
		Dim ciRibbon As ColumnInformation = Nothing
		Dim iSumWidth As Single = 0

		For cols As Integer = 0 To Me.ColumnCount - 1
			ci = Me.GetColumn(cols)
			If (ci.Width = 0) Then ciRibbon = ci

			iSumWidth += ci.Width
		Next

		If (ciRibbon IsNot Nothing) Then
			ciRibbon.Width = width - iSumWidth
		End If
	End Sub
#End Region

#Region " Override of Print Page "
	Protected Overrides Sub OnPrintPage(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
		Dim g As Graphics = e.Graphics
		g.PageUnit = GraphicsUnit.Inch

		'convert to inches
		Dim leftMargin As Single = e.MarginBounds.Left / 100
		Dim rightMargin As Single = e.MarginBounds.Right / 100
		Dim topMargin As Single = e.MarginBounds.Top / 100
		Dim bottomMargin As Single = e.MarginBounds.Bottom / 100
		Dim width As Single = e.MarginBounds.Width / 100
		Dim height As Single = e.MarginBounds.Height / 100
		Dim currentPosition As Single = topMargin

		currentPage += 1

		Dim headerSize As Single
		Dim footerSize As Single

		Dim headerBounds As New RectangleF(leftMargin, topMargin, width, height)

		headerBounds.Height = Me.HeaderHeight
		headerSize = PrintPageHeader(headerBounds, e, False)
		currentPosition += headerSize

		currentPosition += PrintLine(New RectangleF(leftMargin, currentPosition, width, height), e, 0.03, False)
		'want to put in column headers for your detail rows?
		'Add it in here, after the header has been printed,
		'but before any detail rows

		'If you do add column headers, be sure to increment
		'currentPosition by the size of the column headers 
		'so that the detail rows start at the correct position.

		Dim footerBounds As New RectangleF(leftMargin, topMargin, width, height)
		footerBounds.Height = Me.FooterHeight
		footerBounds.Y = topMargin + height - footerBounds.Height

		footerSize = PrintPageFooter(footerBounds, e, False)
		footerSize -= PrintLine(New RectangleF(leftMargin, footerBounds.Y - 0.03, width, height), e, 0.03, False)

		footerBounds.Y -= 0.03

		e.HasMorePages = False

		currentPosition += PrintHeaderRow(leftMargin, currentPosition, Me.MinDetailRowHeight, Me.MaxDetailRowHeight, width, e, False)
		currentPosition += PrintLine(New RectangleF(leftMargin, currentPosition, width, height), e, 0.01, False)

		For rowCounter As Integer = currentRow To Me.DataView.Count - 1
			Dim currentRowHeight As Single = PrintDetailRow(leftMargin, currentPosition, Me.MinDetailRowHeight, Me.MaxDetailRowHeight, width, e, Me.DataView(rowCounter), True)
			currentRowHeight += PrintLine(New RectangleF(leftMargin, currentPosition, width, height), e, 0.01, True)

			If currentPosition + currentRowHeight < footerBounds.Y Then
				'it will fit on the page
				currentPosition += _
				 PrintDetailRow(leftMargin, currentPosition, _
				  MinDetailRowHeight, MaxDetailRowHeight, _
				  width, e, Me.DataView(rowCounter), False)
				'want lines between detail rows?
				'add code in here, after the row prints, or 
				'earlier if you want to be before the row prints.
				currentPosition += PrintLine(New RectangleF(leftMargin, currentPosition, width, height), e, 0.01, False)
			Else
				e.HasMorePages = True
				currentRow = rowCounter
				Exit For
			End If
		Next
	End Sub
#End Region

End Class

Public Class FormatColumnEventArgs
	Inherits EventArgs

	Dim m_OriginalValue As Object
	Dim m_StringValue As String

	Public Property OriginalValue() As Object
		Get
			Return m_OriginalValue
		End Get
		Set(ByVal Value As Object)
			m_OriginalValue = Value
		End Set
	End Property

	Public Property StringValue() As String
		Get
			Return m_StringValue
		End Get
		Set(ByVal Value As String)
			m_StringValue = Value
		End Set
	End Property
End Class

Public Class ColumnInformation
	Private m_Field As String
	Private m_Width As Single
	Private m_HeaderText As String
	Private m_HeaderFont As Font
	Private m_DetailFont As Font
	Private m_Alignment As StringAlignment

	Public Event FormatColumn(ByVal sender As Object, ByRef e As FormatColumnEventArgs)

	Public Function GetString(ByVal Value As Object)
		Dim e As New FormatColumnEventArgs()
		e.OriginalValue = Value
		If Not IsDBNull(Value) Then
			e.StringValue = CStr(Value)
		Else
			e.StringValue = "<NULL>"
		End If

		RaiseEvent FormatColumn(CObj(Me), e)
		Return e.StringValue
	End Function

	Public Sub New(ByVal Field As String, ByVal Width As Single, ByVal Alignment As StringAlignment)
		m_Field = Field
		m_Width = Width
		m_Alignment = Alignment
	End Sub

	Public Property Field() As String
		Get
			Return m_Field
		End Get
		Set(ByVal Value As String)
			m_Field = Value
		End Set
	End Property

	Public Property Width() As Single
		Get
			Return m_Width
		End Get
		Set(ByVal Value As Single)
			m_Width = Value
		End Set
	End Property

	Public Property Alignment() As StringAlignment
		Get
			Return m_Alignment
		End Get
		Set(ByVal Value As StringAlignment)
			m_Alignment = Value
		End Set
	End Property

	Public Property HeaderFont() As Font
		Get
			Return m_HeaderFont
		End Get
		Set(ByVal Value As Font)
			m_HeaderFont = Value
		End Set
	End Property

	Public Property HeaderText() As String
		Get
			Return m_HeaderText
		End Get
		Set(ByVal Value As String)
			m_HeaderText = Value
		End Set
	End Property

	Public Property DetailFont() As Font
		Get
			Return m_DetailFont
		End Get
		Set(ByVal Value As Font)
			m_DetailFont = Value
		End Set
	End Property

End Class
