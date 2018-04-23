using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace ReplaceDefaultActionInListView.Module {
    [DefaultClassOptions, ImageName("BO_Contact")]
    public class AddressBookRecord : BaseObject {
        public AddressBookRecord(Session session) : base(session) { }
        private string name;
        public string Name {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }
        private string email;
        public string Email {
            get { return email; }
            set { SetPropertyValue("Email", ref email, value); }
        }
        private string phoneNumber;
        public string PhoneNumber {
            get { return phoneNumber; }
            set { SetPropertyValue("PhoneNumber", ref phoneNumber, value); }
        }
    }
}
