using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;


namespace ReplaceDefaultActionInListView.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : 
            base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            AddressBookRecord record1 = ObjectSpace.FindObject<AddressBookRecord>(
                CriteriaOperator.Parse("Name == 'Mary Tellitson'"));
            if (record1 == null) {
                record1 = ObjectSpace.CreateObject<AddressBookRecord>();
                record1.Name = "Mary Tellitson";
                record1.Email = "tellitson@example.com";
                record1.PhoneNumber = "+1-555-1112233";
                record1.Save();
            }
            AddressBookRecord record2 = ObjectSpace.FindObject<AddressBookRecord>(
                CriteriaOperator.Parse("Name == 'John Nilsen'"));
            if (record2 == null) {
                record2 = ObjectSpace.CreateObject<AddressBookRecord>();
                record2.Name = "John Nilsen";
                record2.Email = "nilsen@example.com";
                record2.PhoneNumber = "+1-555-4445566";
                record2.Save();
            }
        }
    }
}
