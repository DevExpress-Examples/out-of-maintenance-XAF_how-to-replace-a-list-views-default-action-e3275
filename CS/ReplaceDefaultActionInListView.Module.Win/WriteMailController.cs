using System;
using System.Diagnostics;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.SystemModule;

namespace ReplaceDefaultActionInListView.Module {
    public class WriteMailController : ViewController {
        private SimpleAction writeMailAction;
        public WriteMailController() {
            TargetObjectType = typeof(AddressBookRecord);
            writeMailAction = new SimpleAction(this, "WriteMail", PredefinedCategory.Edit);
            writeMailAction.ToolTip = "Write e-mail to the selected address book record";
            writeMailAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            writeMailAction.ImageName = "BO_Contact";
            writeMailAction.Execute += writeMailAction_Execute;
        }
        void writeMailAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            AddressBookRecord record = (AddressBookRecord)e.CurrentObject;
            string startInfo =
                String.Format("mailto:{0}?body=Hello, {1}!%0A%0A", record.Email, record.Name);
            Process.Start(startInfo);
        }
        private ListViewProcessCurrentObjectController processCurrentObjectController;
        protected override void OnActivated() {
            base.OnActivated();
            processCurrentObjectController =
                Frame.GetController<ListViewProcessCurrentObjectController>();
            if (processCurrentObjectController != null) {
                processCurrentObjectController.CustomProcessSelectedItem +=
                    processCurrentObjectController_CustomProcessSelectedItem;
            }
        }
        private void processCurrentObjectController_CustomProcessSelectedItem(
            object sender, CustomProcessListViewSelectedItemEventArgs e) {
            e.Handled = true;
            writeMailAction.DoExecute();
        }
        public SimpleAction DefaultListViewAction {
            get { return writeMailAction; }
            set { writeMailAction = value; }
        }
        protected override void OnDeactivated() {
            if (processCurrentObjectController != null) {
                processCurrentObjectController.CustomProcessSelectedItem -= 
                    processCurrentObjectController_CustomProcessSelectedItem;
            }
            base.OnDeactivated();
        }
    }
}
