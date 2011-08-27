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
using System.Diagnostics;
using Microsoft.SqlServer.Management.Common;


namespace SQLServerCompanion.Views
{
    /// <summary>
    /// Interaction logic for DBLogonView.xaml
    /// </summary>

     [ViewnameToViewLookupKeyMetadata("DBLogonView", typeof(DBLogonView))]
    public partial class DBLogonView : UserControl, IWorkSpaceAware
    {
        public DBLogonView()
        {
            InitializeComponent();
        }


        #region IWorkSpaceAware Members

        /// <summary>
        /// WorkSpaceContextualData Dependency Property
        /// </summary>
        public static readonly DependencyProperty WorkSpaceContextualDataProperty =
            DependencyProperty.Register("WorkSpaceContextualData", typeof(object), typeof(DBLogonView),
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtServerName.Focus();
            e.Handled = true;
        }

    }
}
