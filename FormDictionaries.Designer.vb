<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDictionaries
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDictionaries))
		Me.tab = New System.Windows.Forms.TabControl
		Me.tpGenre = New System.Windows.Forms.TabPage
		Me.lstGenre = New System.Windows.Forms.ListBox
		Me.tpCompany = New System.Windows.Forms.TabPage
		Me.lstCompany = New System.Windows.Forms.ListBox
		Me.tpDirector = New System.Windows.Forms.TabPage
		Me.lstDirector = New System.Windows.Forms.ListBox
		Me.tpStar = New System.Windows.Forms.TabPage
		Me.lstStar = New System.Windows.Forms.ListBox
		Me.tpType = New System.Windows.Forms.TabPage
		Me.lstType = New System.Windows.Forms.ListBox
		Me.tpDebtor = New System.Windows.Forms.TabPage
		Me.lstDebtor = New System.Windows.Forms.ListBox
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.cmdEdit = New System.Windows.Forms.Button
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdOk = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.tab.SuspendLayout()
		Me.tpGenre.SuspendLayout()
		Me.tpCompany.SuspendLayout()
		Me.tpDirector.SuspendLayout()
		Me.tpStar.SuspendLayout()
		Me.tpType.SuspendLayout()
		Me.tpDebtor.SuspendLayout()
		Me.SuspendLayout()
		'
		'tab
		'
		Me.tab.AccessibleDescription = Nothing
		Me.tab.AccessibleName = Nothing
		resources.ApplyResources(Me.tab, "tab")
		Me.tab.BackgroundImage = Nothing
		Me.tab.Controls.Add(Me.tpGenre)
		Me.tab.Controls.Add(Me.tpCompany)
		Me.tab.Controls.Add(Me.tpDirector)
		Me.tab.Controls.Add(Me.tpStar)
		Me.tab.Controls.Add(Me.tpType)
		Me.tab.Controls.Add(Me.tpDebtor)
		Me.tab.Font = Nothing
		Me.tab.Name = "tab"
		Me.tab.SelectedIndex = 0
		'
		'tpGenre
		'
		Me.tpGenre.AccessibleDescription = Nothing
		Me.tpGenre.AccessibleName = Nothing
		resources.ApplyResources(Me.tpGenre, "tpGenre")
		Me.tpGenre.BackgroundImage = Nothing
		Me.tpGenre.Controls.Add(Me.lstGenre)
		Me.tpGenre.Font = Nothing
		Me.tpGenre.Name = "tpGenre"
		Me.tpGenre.UseVisualStyleBackColor = True
		'
		'lstGenre
		'
		Me.lstGenre.AccessibleDescription = Nothing
		Me.lstGenre.AccessibleName = Nothing
		resources.ApplyResources(Me.lstGenre, "lstGenre")
		Me.lstGenre.BackgroundImage = Nothing
		Me.lstGenre.Font = Nothing
		Me.lstGenre.FormattingEnabled = True
		Me.lstGenre.Name = "lstGenre"
		Me.lstGenre.Sorted = True
		'
		'tpCompany
		'
		Me.tpCompany.AccessibleDescription = Nothing
		Me.tpCompany.AccessibleName = Nothing
		resources.ApplyResources(Me.tpCompany, "tpCompany")
		Me.tpCompany.BackgroundImage = Nothing
		Me.tpCompany.Controls.Add(Me.lstCompany)
		Me.tpCompany.Font = Nothing
		Me.tpCompany.Name = "tpCompany"
		Me.tpCompany.UseVisualStyleBackColor = True
		'
		'lstCompany
		'
		Me.lstCompany.AccessibleDescription = Nothing
		Me.lstCompany.AccessibleName = Nothing
		resources.ApplyResources(Me.lstCompany, "lstCompany")
		Me.lstCompany.BackgroundImage = Nothing
		Me.lstCompany.Font = Nothing
		Me.lstCompany.FormattingEnabled = True
		Me.lstCompany.Name = "lstCompany"
		Me.lstCompany.Sorted = True
		'
		'tpDirector
		'
		Me.tpDirector.AccessibleDescription = Nothing
		Me.tpDirector.AccessibleName = Nothing
		resources.ApplyResources(Me.tpDirector, "tpDirector")
		Me.tpDirector.BackgroundImage = Nothing
		Me.tpDirector.Controls.Add(Me.lstDirector)
		Me.tpDirector.Font = Nothing
		Me.tpDirector.Name = "tpDirector"
		Me.tpDirector.UseVisualStyleBackColor = True
		'
		'lstDirector
		'
		Me.lstDirector.AccessibleDescription = Nothing
		Me.lstDirector.AccessibleName = Nothing
		resources.ApplyResources(Me.lstDirector, "lstDirector")
		Me.lstDirector.BackgroundImage = Nothing
		Me.lstDirector.Font = Nothing
		Me.lstDirector.FormattingEnabled = True
		Me.lstDirector.Name = "lstDirector"
		Me.lstDirector.Sorted = True
		'
		'tpStar
		'
		Me.tpStar.AccessibleDescription = Nothing
		Me.tpStar.AccessibleName = Nothing
		resources.ApplyResources(Me.tpStar, "tpStar")
		Me.tpStar.BackgroundImage = Nothing
		Me.tpStar.Controls.Add(Me.lstStar)
		Me.tpStar.Font = Nothing
		Me.tpStar.Name = "tpStar"
		Me.tpStar.UseVisualStyleBackColor = True
		'
		'lstStar
		'
		Me.lstStar.AccessibleDescription = Nothing
		Me.lstStar.AccessibleName = Nothing
		resources.ApplyResources(Me.lstStar, "lstStar")
		Me.lstStar.BackgroundImage = Nothing
		Me.lstStar.Font = Nothing
		Me.lstStar.FormattingEnabled = True
		Me.lstStar.Name = "lstStar"
		Me.lstStar.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
		Me.lstStar.Sorted = True
		'
		'tpType
		'
		Me.tpType.AccessibleDescription = Nothing
		Me.tpType.AccessibleName = Nothing
		resources.ApplyResources(Me.tpType, "tpType")
		Me.tpType.BackgroundImage = Nothing
		Me.tpType.Controls.Add(Me.lstType)
		Me.tpType.Font = Nothing
		Me.tpType.Name = "tpType"
		Me.tpType.UseVisualStyleBackColor = True
		'
		'lstType
		'
		Me.lstType.AccessibleDescription = Nothing
		Me.lstType.AccessibleName = Nothing
		resources.ApplyResources(Me.lstType, "lstType")
		Me.lstType.BackgroundImage = Nothing
		Me.lstType.Font = Nothing
		Me.lstType.FormattingEnabled = True
		Me.lstType.Name = "lstType"
		Me.lstType.Sorted = True
		'
		'tpDebtor
		'
		Me.tpDebtor.AccessibleDescription = Nothing
		Me.tpDebtor.AccessibleName = Nothing
		resources.ApplyResources(Me.tpDebtor, "tpDebtor")
		Me.tpDebtor.BackgroundImage = Nothing
		Me.tpDebtor.Controls.Add(Me.lstDebtor)
		Me.tpDebtor.Font = Nothing
		Me.tpDebtor.Name = "tpDebtor"
		Me.tpDebtor.UseVisualStyleBackColor = True
		'
		'lstDebtor
		'
		Me.lstDebtor.AccessibleDescription = Nothing
		Me.lstDebtor.AccessibleName = Nothing
		resources.ApplyResources(Me.lstDebtor, "lstDebtor")
		Me.lstDebtor.BackgroundImage = Nothing
		Me.lstDebtor.Font = Nothing
		Me.lstDebtor.FormattingEnabled = True
		Me.lstDebtor.Name = "lstDebtor"
		Me.lstDebtor.Sorted = True
		'
		'cmdAdd
		'
		Me.cmdAdd.AccessibleDescription = Nothing
		Me.cmdAdd.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdAdd, "cmdAdd")
		Me.cmdAdd.BackgroundImage = Nothing
		Me.cmdAdd.Font = Nothing
		Me.cmdAdd.Name = "cmdAdd"
		Me.cmdAdd.UseVisualStyleBackColor = True
		'
		'cmdEdit
		'
		Me.cmdEdit.AccessibleDescription = Nothing
		Me.cmdEdit.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdEdit, "cmdEdit")
		Me.cmdEdit.BackgroundImage = Nothing
		Me.cmdEdit.Font = Nothing
		Me.cmdEdit.Name = "cmdEdit"
		Me.cmdEdit.UseVisualStyleBackColor = True
		'
		'cmdDelete
		'
		Me.cmdDelete.AccessibleDescription = Nothing
		Me.cmdDelete.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdDelete, "cmdDelete")
		Me.cmdDelete.BackgroundImage = Nothing
		Me.cmdDelete.Font = Nothing
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdDelete.UseVisualStyleBackColor = True
		'
		'cmdOk
		'
		Me.cmdOk.AccessibleDescription = Nothing
		Me.cmdOk.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdOk, "cmdOk")
		Me.cmdOk.BackgroundImage = Nothing
		Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.cmdOk.Font = Nothing
		Me.cmdOk.Name = "cmdOk"
		Me.cmdOk.UseVisualStyleBackColor = True
		'
		'cmdCancel
		'
		Me.cmdCancel.AccessibleDescription = Nothing
		Me.cmdCancel.AccessibleName = Nothing
		resources.ApplyResources(Me.cmdCancel, "cmdCancel")
		Me.cmdCancel.BackgroundImage = Nothing
		Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdCancel.Font = Nothing
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdCancel.UseVisualStyleBackColor = True
		'
		'FormDictionaries
		'
		Me.AcceptButton = Me.cmdOk
		Me.AccessibleDescription = Nothing
		Me.AccessibleName = Nothing
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Nothing
		Me.CancelButton = Me.cmdCancel
		Me.Controls.Add(Me.cmdDelete)
		Me.Controls.Add(Me.cmdAdd)
		Me.Controls.Add(Me.cmdCancel)
		Me.Controls.Add(Me.cmdEdit)
		Me.Controls.Add(Me.cmdOk)
		Me.Controls.Add(Me.tab)
		Me.Font = Nothing
		Me.Icon = Nothing
		Me.MinimizeBox = False
		Me.Name = "FormDictionaries"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.tab.ResumeLayout(False)
		Me.tpGenre.ResumeLayout(False)
		Me.tpCompany.ResumeLayout(False)
		Me.tpDirector.ResumeLayout(False)
		Me.tpStar.ResumeLayout(False)
		Me.tpType.ResumeLayout(False)
		Me.tpDebtor.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents tab As System.Windows.Forms.TabControl
	Friend WithEvents tpType As System.Windows.Forms.TabPage
	Friend WithEvents tpCompany As System.Windows.Forms.TabPage
	Friend WithEvents cmdAdd As System.Windows.Forms.Button
	Friend WithEvents cmdEdit As System.Windows.Forms.Button
	Friend WithEvents cmdDelete As System.Windows.Forms.Button
	Friend WithEvents cmdOk As System.Windows.Forms.Button
	Friend WithEvents cmdCancel As System.Windows.Forms.Button
	Friend WithEvents tpGenre As System.Windows.Forms.TabPage
	Friend WithEvents lstGenre As System.Windows.Forms.ListBox
	Friend WithEvents lstCompany As System.Windows.Forms.ListBox
	Friend WithEvents tpDirector As System.Windows.Forms.TabPage
	Friend WithEvents lstDirector As System.Windows.Forms.ListBox
	Friend WithEvents tpStar As System.Windows.Forms.TabPage
	Friend WithEvents lstStar As System.Windows.Forms.ListBox
	Friend WithEvents lstType As System.Windows.Forms.ListBox
	Friend WithEvents tpDebtor As System.Windows.Forms.TabPage
	Friend WithEvents lstDebtor As System.Windows.Forms.ListBox
End Class
