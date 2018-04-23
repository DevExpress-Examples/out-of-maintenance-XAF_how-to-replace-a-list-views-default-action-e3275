Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel

Imports DevExpress.ExpressApp

Namespace ReplaceDefaultActionInListView.Module.Win
    <ToolboxItemFilter("Xaf.Platform.Win")> _
    Public NotInheritable Partial Class ReplaceDefaultActionInListViewWindowsFormsModule
        Inherits ModuleBase

        Public Sub New()
            ModelDifferenceResourceName = "ReplaceDefaultActionInListView.Module.Win.Model.DesignedDiffs"
            InitializeComponent()
        End Sub
    End Class
End Namespace
