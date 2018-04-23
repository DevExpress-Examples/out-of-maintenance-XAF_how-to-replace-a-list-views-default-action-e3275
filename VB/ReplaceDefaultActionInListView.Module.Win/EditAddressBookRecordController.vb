Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent.Base

Namespace ReplaceDefaultActionInListView.Module.Win
    Public Class EditAddressBookRecordController
        Inherits ViewController(Of ListView)

        Public Sub New()
            TargetObjectType = GetType(AddressBookRecord)
            Dim editAddressBookRecordAction As New SimpleAction(Me, "EditAddressBookRecord", PredefinedCategory.Edit)
            editAddressBookRecordAction.ImageName = "Action_Edit"
            editAddressBookRecordAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject
            AddHandler editAddressBookRecordAction.Execute, AddressOf editAddressBookRecordAction_Execute
        End Sub
        Private Sub editAddressBookRecordAction_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs)
            ListViewProcessCurrentObjectController.ShowObject(e.CurrentObject, e.ShowViewParameters, Application, Frame, View)
        End Sub
    End Class
End Namespace
