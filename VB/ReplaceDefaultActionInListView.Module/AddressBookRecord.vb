Imports Microsoft.VisualBasic
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
        Private _name As String
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Name", _name, value)
            End Set
        End Property
        Private _email As String
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Email", _email, value)
            End Set
        End Property
        Private _phoneNumber As String
        Public Property PhoneNumber() As String
            Get
                Return _phoneNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue("PhoneNumber", _phoneNumber, value)
            End Set
        End Property
    End Class
End Namespace
