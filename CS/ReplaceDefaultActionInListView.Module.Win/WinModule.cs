using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace ReplaceDefaultActionInListView.Module.Win {
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class ReplaceDefaultActionInListViewWindowsFormsModule : ModuleBase {
        public ReplaceDefaultActionInListViewWindowsFormsModule() {
            ModelDifferenceResourceName = "ReplaceDefaultActionInListView.Module.Win.Model.DesignedDiffs";
            InitializeComponent();
        }
    }
}
