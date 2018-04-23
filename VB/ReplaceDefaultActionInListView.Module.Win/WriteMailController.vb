Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.SystemModule

Namespace ReplaceDefaultActionInListView.Module
    Public Class WriteMailController
        Inherits ViewController
        Private writeMailAction As SimpleAction
        Public Sub New()
            TargetObjectType = GetType(AddressBookRecord)
            writeMailAction = New SimpleAction(Me, "WriteMail", PredefinedCategory.Edit)
            writeMailAction.ToolTip = "Write e-mail to the selected address book record"
            writeMailAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject
            writeMailAction.ImageName = "BO_Contact"
            AddHandler writeMailAction.Execute, AddressOf writeMailAction_Execute
        End Sub
        Private Sub writeMailAction_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs)
            Dim record As AddressBookRecord = CType(e.CurrentObject, AddressBookRecord)
            Dim startInfo As String = String.Format("mailto:{0}?body=Hello, {1}!%0A%0A", record.Email, record.Name)
            Process.Start(startInfo)
        End Sub
        Protected Overrides Overloads Sub OnActivated()
            MyBase.OnActivated()
            Dim processCurrentObjectController As ListViewProcessCurrentObjectController = Frame.GetController(Of ListViewProcessCurrentObjectController)()
            If processCurrentObjectController IsNot Nothing Then
                AddHandler processCurrentObjectController.CustomProcessSelectedItem, AddressOf processCurrentObjectController_CustomProcessSelectedItem
            End If
        End Sub
        Private Sub processCurrentObjectController_CustomProcessSelectedItem(ByVal sender As Object, ByVal e As CustomProcessListViewSelectedItemEventArgs)
            e.Handled = True
            writeMailAction.DoExecute()
        End Sub
        Public Property DefaultListViewAction() As SimpleAction
            Get
                Return writeMailAction
            End Get
            Set(ByVal value As SimpleAction)
                writeMailAction = value
            End Set
        End Property
    End Class
End Namespace
