using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cinch;
using Codeplex.Dashboarding;

namespace SQLServerCompanion.Views
{
    /// <summary>
    /// Interaction logic for HomepageView.xaml
    /// </summary>

    [ViewnameToViewLookupKeyMetadata("HomepageView", typeof(HomepageView))]
    public partial class HomepageView : UserControl, IWorkSpaceAware
    {
        public HomepageView()
        {
            InitializeComponent();
        }

        #region IWorkSpaceAware Members

        /// <summary>
        /// WorkSpaceContextualData Dependency Property
        /// </summary>
        public static readonly DependencyProperty WorkSpaceContextualDataProperty =
            DependencyProperty.Register("WorkSpaceContextualData", typeof(object), typeof(HomepageView),
                new FrameworkPropertyMetadata((WorkspaceData)null));

        /// <summary>
        /// Gets or sets the WorkSpaceContextualData property.  
        /// </summary>
        public WorkspaceData WorkSpaceContextualData
        {
            get { return (WorkspaceData)GetValue(WorkSpaceContextualDataProperty); }
            set { SetValue(WorkSpaceContextualDataProperty, value); }
        }

        #endregion
    }
}
