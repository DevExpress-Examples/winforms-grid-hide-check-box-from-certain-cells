Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Repository

Namespace HideCheckEdit

    ''' <summary>
    ''' Summary description for Form1.
    ''' </summary>
    Public Class Form1
        Inherits Form

        Private gridControl1 As DevExpress.XtraGrid.GridControl

        Private gridView1 As GridView

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()
        '
        ' TODO: Add any constructor code after InitializeComponent call
        '
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            gridControl1 = New DevExpress.XtraGrid.GridControl()
            gridView1 = New GridView()
            CType(gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridControl1
            ' 
            gridControl1.Dock = DockStyle.Fill
            gridControl1.EmbeddedNavigator.Name = ""
            gridControl1.Location = New System.Drawing.Point(0, 0)
            gridControl1.MainView = gridView1
            gridControl1.Name = "gridControl1"
            gridControl1.Size = New System.Drawing.Size(600, 373)
            gridControl1.TabIndex = 0
            gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {gridView1})
            ' 
            ' gridView1
            ' 
            gridView1.GridControl = gridControl1
            gridView1.Name = "gridView1"
            AddHandler gridView1.CustomRowCellEdit, New CustomRowCellEditEventHandler(AddressOf gridView1_CustomRowCellEdit)
            ' 
            ' Form1
            ' 
            AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            ClientSize = New System.Drawing.Size(600, 373)
            Me.Controls.Add(gridControl1)
            Name = "Form1"
            Text = "Form1"
            AddHandler Load, New EventHandler(AddressOf Form1_Load)
            CType(gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(gridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Shared Sub Main()
            Call Application.Run(New Form1())
        End Sub

        Private emptyEditor As RepositoryItem

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            emptyEditor = New RepositoryItem()
            gridControl1.RepositoryItems.Add(emptyEditor)
            Dim tmp_XViewsPrinting = New DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1)
        End Sub

        Private Function NeedToHideDiscontinuedCheckbox(ByVal view As GridView, ByVal row As Integer) As Boolean
            Return Equals(view.GetRowCellDisplayText(row, "Category"), "Dairy Products")
        End Function

        Private Sub gridView1_CustomRowCellEdit(ByVal sender As Object, ByVal e As CustomRowCellEditEventArgs)
            If Equals(e.Column.FieldName, "Discontinued") AndAlso NeedToHideDiscontinuedCheckbox(TryCast(sender, GridView), e.RowHandle) Then e.RepositoryItem = emptyEditor
        End Sub
    End Class
End Namespace
