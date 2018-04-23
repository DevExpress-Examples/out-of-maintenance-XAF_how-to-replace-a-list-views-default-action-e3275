Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.ExpressApp

Namespace ReplaceDefaultActionInListView.Win
    Partial Public Class ReplaceDefaultActionInListViewWindowsFormsApplication
        Inherits WinApplication
        Public Sub New()
            InitializeComponent()
            DelayedViewItemsInitialization = True
        End Sub
        Private Sub ReplaceDefaultActionInListViewWindowsFormsApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
            e.Updater.Update()
            e.Handled = True
        End Sub
    End Class
End Namespace
