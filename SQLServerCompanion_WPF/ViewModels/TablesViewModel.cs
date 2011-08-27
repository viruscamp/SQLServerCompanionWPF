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
using System.Data;
using System.Collections.Specialized;
using SQLServerCompanion.HelperClasses;
using System.Reflection;

namespace SQLServerCompanion.ViewModels
{
    [ExportViewModel("TablesViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TablesViewModel : ViewModelBase
    {
        public IUIVisualizerService uiVisualizer;
        private IMessageBoxService messageBoxService;
        private IViewAwareStatus viewAwareStatusService;
        private BackgroundWorker _backgroundWorker;

        [ImportingConstructor]
        public TablesViewModel(IUIVisualizerService uiVisualizer, IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatusService)
        {
            this.uiVisualizer = uiVisualizer;
            this.messageBoxService = messageBoxService;
            this.viewAwareStatusService = viewAwareStatusService;
            this.viewAwareStatusService.ViewLoaded += ViewAwareStatusService_ViewLoaded;

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;            
        }

        #region Methods

        private void ViewAwareStatusService_ViewLoaded()
        {
            if (!Designer.IsInDesignMode)
            {
                var view = viewAwareStatusService.View;
                IWorkSpaceAware workspaceData = (IWorkSpaceAware)view;
                SelectedTable = (Table)workspaceData.WorkSpaceContextualData.DataValue;               
                
                _backgroundWorker.RunWorkerAsync();
            }
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string sqlScript = "";

            IsLoading = true;

            sqlScript = ScriptTableSchema();

            DataSet ds = new DataSet();

            ds = SelectedDB.ExecuteWithResults(GetTableSelectStatement());

            TableData = ds;

            e.Result = sqlScript;
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                IsLoading = false;
                throw e.Error;
                
            }
            else
            {
                SQLScript = e.Result as string;
                IsLoading = false;
            }
        }


        private string ScriptTableSchema()
        {
            string sqlScript = "";

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

            sqlScript = sb.ToString();

            return sqlScript;
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

            if (SelectedTable.Indexes.Count > 0)
            {
                foreach (Index index in SelectedTable.Indexes)
                {
                    if (index.IndexKeyType == IndexKeyType.DriPrimaryKey)
                    {
                        key = index.IndexedColumns[0].Name;
                    }
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

        public Database SelectedDB
        {
            get { return DBServerConnectionSingleton.Instance.SelectedDB; }

        }

        private Table _SelectedTable;
        public Table SelectedTable
        {
            get { return _SelectedTable; }

            set
            {
                _SelectedTable = value;
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

        private string _sqlScript ;
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

        #endregion

    }//class
}//namespace

