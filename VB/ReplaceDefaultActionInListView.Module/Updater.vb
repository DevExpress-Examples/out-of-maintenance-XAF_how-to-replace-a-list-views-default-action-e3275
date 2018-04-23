Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering


Namespace ReplaceDefaultActionInListView.Module
    Public Class Updater
        Inherits ModuleUpdater
        Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub
        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
            Dim record1 As AddressBookRecord = ObjectSpace.FindObject(Of AddressBookRecord)(CriteriaOperator.Parse("Name == 'Mary Tellitson'"))
            If record1 Is Nothing Then
                record1 = ObjectSpace.CreateObject(Of AddressBookRecord)()
                record1.Name = "Mary Tellitson"
                record1.Email = "tellitson@example.com"
                record1.PhoneNumber = "+1-555-1112233"
                record1.Save()
            End If
            Dim record2 As AddressBookRecord = ObjectSpace.FindObject(Of AddressBookRecord)(CriteriaOperator.Parse("Name == 'John Nilsen'"))
            If record2 Is Nothing Then
                record2 = ObjectSpace.CreateObject(Of AddressBookRecord)()
                record2.Name = "John Nilsen"
                record2.Email = "nilsen@example.com"
                record2.PhoneNumber = "+1-555-4445566"
                record2.Save()
            End If
        End Sub
    End Class
End Namespace
