using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;

namespace ReplaceDefaultActionInListView.Module.Win {
    public class EditAddressBookRecordController : ViewController<ListView> {
        public EditAddressBookRecordController() {
            TargetObjectType = typeof(AddressBookRecord);
            SimpleAction editAddressBookRecordAction = 
                new SimpleAction(this, "EditAddressBookRecord", PredefinedCategory.Edit);
            editAddressBookRecordAction.ImageName = "Action_Edit";
            editAddressBookRecordAction.SelectionDependencyType = 
                SelectionDependencyType.RequireSingleObject;
            editAddressBookRecordAction.Execute += editAddressBookRecordAction_Execute;
        }
        void editAddressBookRecordAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            ListViewProcessCurrentObjectController.ShowObject(
                e.CurrentObject, e.ShowViewParameters, Application, Frame, View);
        }
    }
}
