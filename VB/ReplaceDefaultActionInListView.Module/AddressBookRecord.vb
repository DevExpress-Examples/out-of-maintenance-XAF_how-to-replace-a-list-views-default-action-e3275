Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace ReplaceDefaultActionInListView.Module
    <DefaultClassOptions, ImageName("BO_Contact")> _
    Public Class AddressBookRecord
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private name_Renamed As String
        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Name", name_Renamed, value)
            End Set
        End Property

        Private email_Renamed As String
        Public Property Email() As String
            Get
                Return email_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Email", email_Renamed, value)
            End Set
        End Property

        Private phoneNumber_Renamed As String
        Public Property PhoneNumber() As String
            Get
                Return phoneNumber_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("PhoneNumber", phoneNumber_Renamed, value)
            End Set
        End Property
    End Class
End Namespace
