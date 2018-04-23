Imports System
Imports System.Diagnostics
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base


Namespace ReplaceDefaultActionInListView.Module
    Public Class PhoneCallController
        Inherits ViewController

        Private phoneCallAction As SimpleAction
        Public Sub New()
            TargetObjectType = GetType(AddressBookRecord)
            phoneCallAction = New SimpleAction(Me, "PhoneCall", PredefinedCategory.Edit)
            phoneCallAction.ToolTip = "Call the current record via Skype"
            phoneCallAction.ImageName = "BO_Phone"
            phoneCallAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject
            AddHandler phoneCallAction.Execute, AddressOf skypeCallAction_Execute
        End Sub
        Private Sub skypeCallAction_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs)
            Process.Start("skype:" & CType(e.CurrentObject, AddressBookRecord).PhoneNumber)
        End Sub
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            AddHandler View.CurrentObjectChanged, AddressOf View_CurrentObjectChanged
            ' Comment out the following three lines to leave "Write Mail" action as default:
            Dim writeMailController As WriteMailController = Frame.GetController(Of WriteMailController)()
            If writeMailController IsNot Nothing Then
                writeMailController.DefaultListViewAction = phoneCallAction
            End If
        End Sub
        Private Sub View_CurrentObjectChanged(ByVal sender As Object, ByVal e As EventArgs)
            phoneCallAction.Enabled.SetItemValue("PhoneIsSpecified", (Not String.IsNullOrEmpty(CType(View.CurrentObject, AddressBookRecord).PhoneNumber)))
        End Sub
    End Class
End Namespace
