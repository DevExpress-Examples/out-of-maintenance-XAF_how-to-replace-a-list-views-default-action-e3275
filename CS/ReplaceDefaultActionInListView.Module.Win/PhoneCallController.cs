using System;
using System.Diagnostics;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;


namespace ReplaceDefaultActionInListView.Module {
    public class PhoneCallController : ViewController {
        private SimpleAction phoneCallAction;
        public PhoneCallController() {
            TargetObjectType = typeof(AddressBookRecord);
            phoneCallAction = new SimpleAction(this, "PhoneCall", PredefinedCategory.Edit);
            phoneCallAction.ToolTip = "Call the current record via Skype";
            phoneCallAction.ImageName = "BO_Phone";
            phoneCallAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            phoneCallAction.Execute += skypeCallAction_Execute;
        }
        void skypeCallAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            Process.Start("skype:" + ((AddressBookRecord)e.CurrentObject).PhoneNumber);
        }
        protected override void OnActivated() {
            base.OnActivated();
            View.CurrentObjectChanged += View_CurrentObjectChanged;
            // Comment out the following three lines to leave "Write Mail" action as default:
            WriteMailController writeMailController = Frame.GetController<WriteMailController>();
            if (writeMailController != null)
                writeMailController.DefaultListViewAction = phoneCallAction;
        }
        void View_CurrentObjectChanged(object sender, EventArgs e) {
            phoneCallAction.Enabled.SetItemValue("PhoneIsSpecified",
                !String.IsNullOrEmpty(((AddressBookRecord)View.CurrentObject).PhoneNumber));
        }
    }
}
