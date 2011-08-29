using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Composition;
using Microsoft.SqlServer.Management.Smo;

using MEFedMVVM.ViewModelLocator;
using Cinch;
using MEFedMVVM.Common;
using System.Collections.ObjectModel;
using SQLServerCompanion.HelperClasses;
using System.Windows;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Threading;
using System.Reflection;

namespace SQLServerCompanion.ViewModels
{
    [ExportViewModel("HomepageViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomepageViewModel : ViewModelBase
    {
        public IUIVisualizerService uiVisualizer;
        private IMessageBoxService messageBoxService;
        private IViewAwareStatus viewAwareStatusService;
        private BackgroundWorker _backgroundWorker;
        private BusinessLogic cn = null;
        private static SimpleRule dbSelectedRule;
        private MainWindowViewModel vmMainWindow;

        [ImportingConstructor]
        public HomepageViewModel(IUIVisualizerService uiVisualizer, IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatusService)
        {
            this.uiVisualizer = uiVisualizer;
            this.messageBoxService = messageBoxService;
            this.viewAwareStatusService = viewAwareStatusService;
            this.viewAwareStatusService.ViewLoaded += ViewAwareStatusService_ViewLoaded;

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;

            //Commands
            DoScriptCommand = new SimpleCommand<Object, Object>(ExecuteDoScriptCommand);

        }


        #region Methods 


        private void ViewAwareStatusService_ViewLoaded()
        {
            if (!Designer.IsInDesignMode)
            {
                var view = viewAwareStatusService.View;
                IWorkSpaceAware workspaceData = (IWorkSpaceAware)view;
                ViewsLocal = workspaceData.WorkSpaceContextualData.DataValue as ObservableCollection<WorkspaceData>;
                MainWindowViewModel vm = workspaceData.WorkSpaceContextualData.ViewModelInstance as MainWindowViewModel;
                if (vm != null)
                {
                    SelectedDB = vm.SelectedDB;
                }

            }
            
        }

        private void ExecuteDoScriptCommand(Object args)
        {
            if (SelectedDB == null)
            {
                messageBoxService.ShowInformation("Please select a database.");
            }
            else
            {
                IsLoading = true;
                _backgroundWorker.RunWorkerAsync();
            }
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //cn = new BusinessLogic();
            
            //e.Result = cn.ScriptEverything(SelectedDB, new ObjectsToScriptOptions();

        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {

                throw e.Error;
            }
            else
            {
                SQLScript = e.Result as string;

                WorkspaceData workspace2 = new WorkspaceData("", "TablesView", SQLScript, "DB Script", true);                
                ViewsLocal.Add(workspace2);

                WorkspaceData workspace3 = new WorkspaceData("", "IndexesView", cn.SQLScriptIndexes, "Indexes", true);
                ViewsLocal.Add(workspace3);                
                
                WorkspaceData workspace4 = new WorkspaceData("", "ForeignKeysView",cn.SQLScriptForeignKeysDrop + Environment.NewLine + cn.SQLScriptForeignKeysAdd, "Foreign Keys", true);
                ViewsLocal.Add(workspace4);

                WorkspaceData workspace5 = new WorkspaceData("", "TriggersView", cn.SQLScriptTriggers, "Triggers", true);
                ViewsLocal.Add(workspace5);

                WorkspaceData workspace6 = new WorkspaceData("", "StoredProcsView", cn.SQLScriptStoredProcs, "Stored Procs", true);
                ViewsLocal.Add(workspace6);

                WorkspaceData workspace7 = new WorkspaceData("", "DBViewsView", cn.SQLScriptViews, "Views", true);
                ViewsLocal.Add(workspace7);

                SetActiveWorkspace(workspace2);                                

                IsLoading = false;
            }

        }

        private void LoadTableData()
        {
            IsLoading = true;

            StringBuilder sb = new StringBuilder();

            ScriptingOptions options = new ScriptingOptions();
            options.NoCollation = true;
            options.ClusteredIndexes = true;
            options.Default = true;
            options.DriAll = true;
            options.Indexes = true;
            options.IncludeHeaders = true;
            options.IncludeIfNotExists = true;
            options.Triggers = true;
            options.SchemaQualify = true;

            StringCollection coll = SelectedTable.Script(options);
            foreach (string str in coll)
            {
                sb.Append(str);
                sb.Append(Environment.NewLine);
            }
            sb.AppendLine("GO");

            SQLScript = sb.ToString();

            DataSet ds = new DataSet();
            
            ds = SelectedDB.ExecuteWithResults(GetTableSelectStatement());
            
            TableData = ds;
            var results = ds.Tables[0].Select().Skip(2).Take(50).ToList<object>();
            DataRow tmp = results[5] as DataRow;

            IsLoading = false;

            
        }

        private string GetTableSelectStatement()
        {
            string sql = "SELECT TOP 50 * FROM ";

            string tableName = "";

            tableName = "[" + SelectedTable.Schema + "]." + "[" + SelectedTable.Name + "]";

            sql += tableName;

            sql += GetPrimaryKeyColumn();

            return sql;
        }

        private string GetPrimaryKeyColumn()
        {
            string key = null;

            string returnSQL = "";

            if (SelectedTable.Indexes.Count > 0 )
            {
                if (SelectedTable.Indexes[0].IndexedColumns.Count > 0 )
                {
                    key = SelectedTable.Indexes[0].IndexedColumns[0].Name;
                }
            }

            if (key != null)
            {
                returnSQL = " ORDER BY " + key + " DESC";
            }

            return returnSQL;
        }
        #endregion        
        
        #region Public properties

        public SimpleCommand<object, object> DoScriptCommand { get; private set; }

        private Database _SelectedDB;
        public Database SelectedDB
        {
            get { return _SelectedDB; }

            set
            {
                _SelectedDB = value;
            }
        }

        private Table _SelectedTable;
        public Table SelectedTable
        {
            get { return _SelectedTable; }

            set
            {
                _SelectedTable = value;
                LoadTableData();
            }
        }

        private bool _IsLoading = false;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set
            {
                _IsLoading = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        private string _sqlScript = "SQL Script goes here.";
        public string SQLScript
        {
            get { return _sqlScript; }
            set
            {
                _sqlScript = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        private DataSet _tableData;
        public DataSet TableData
        {
            get { return _tableData; }
            set
            {
                _tableData = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        public ObservableCollection<WorkspaceData> ViewsLocal { get; set; }

        #endregion

    }//class

}//namespace
