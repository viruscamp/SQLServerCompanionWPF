using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.SqlServer.Management.Smo;
using SQLServerCompanion.HelperClasses;
using SQLServerCompanion.Views;

using MEFedMVVM.ViewModelLocator;
using Cinch;
using MEFedMVVM.Common;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using Microsoft.SqlServer.Management.Common;

namespace SQLServerCompanion.ViewModels
{
    /// <summary>
    /// The aim of this application is to provide common functionality that a developer regularly uses in their daily jobs
    /// with the least amount of clicks. e.g. SQL Management Studio is nice but 90% of the time, all I want to do is view the recent data inserted into a table,
    /// for this I have to right click and then select TOP 1000 etc... With SQL Server Companion, it just takes a double click.
    /// Similarly, I wrote this application to help me quickly script db objects as part of release management.
    /// And finally, it isn't easy to view triggers in SQL Management Studio, you have to expand each table view and look in the triggers section, with this
    /// application you can simply select to view the triggers from the combo box option.
    /// 
    /// This application is a work in progress and in no way is a model application but it is a start in the right direction for anybody looking for a sample and detailed WPF project.
    /// 
    /// </summary>
    [ExportViewModel("MainWindowViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainWindowViewModel : ViewModelBase
    {

        #region Private properties
        Server _SQLServer = null;

        private bool showContextMenu = false;
        private IViewAwareStatus viewAwareStatusService;
        private IMessageBoxService messageBoxService;

        private BackgroundWorker _generateScriptsBackgroundWorker;
        BusinessLogic cn = null;
        CancellationTokenSource cts;
        private DispatcherTimer timer_batchRequestsPerSecond;

        #endregion

        #region Constructor

        [ImportingConstructor]
        public MainWindowViewModel(IViewAwareStatus viewAwareStatusService, IMessageBoxService messageBoxService)
        {
            this.viewAwareStatusService = viewAwareStatusService;
            this.viewAwareStatusService.ViewLoaded += ViewAwareStatusService_ViewLoaded;
            this.messageBoxService = messageBoxService;

            //Create an instance of the background worker used for generating the script events.
            _generateScriptsBackgroundWorker = new BackgroundWorker();
            _generateScriptsBackgroundWorker.DoWork += _generateScriptsBackgroundWorker_DoWork;
            _generateScriptsBackgroundWorker.RunWorkerCompleted += _generateScriptsBackgroundWorker_RunWorkerCompleted;

            InitialiseViewModel();
        }

        #endregion

        #region Methods

        private void InitialiseViewModel()
        {
            DBServerConnectionSingleton.Instance.DBServerName = SQLServerCompanion.Properties.Settings.Default.SQLServerName;
            DBServerConnectionSingleton.Instance.Username = SQLServerCompanion.Properties.Settings.Default.SQLUsername;
            DBServerConnectionSingleton.Instance.Password = SQLServerCompanion.Properties.Settings.Default.SQLPassword;
            DBServerConnectionSingleton.Instance.UseIntegratedAuthentication = SQLServerCompanion.Properties.Settings.Default.UseIntegratedAuthentication;
            DBServerConnectionSingleton.Instance.SelectedNetworkProtocol = SQLServerCompanion.Properties.Settings.Default.NetworkProtocol;

            //Initialise the commands
            DBSelectedCommand = new SimpleCommand<Object, EventToCommandArgs>(ExecuteDBSelectedCommand);
            SelectedObjectDoubleClickedCommand = new SimpleCommand<Object, EventToCommandArgs>(ExecuteSelectedObjectDoubleClickedCommand);
            DoLogonCommand = new SimpleCommand<Object, Object>(ExecuteDoLogonCommand);
            DoDisconnectDBCommand = new SimpleCommand<Object, Object>(ExecuteDoDisconnectDBCommand);
            DoCloseLogonPopupCommand = new SimpleCommand<Object, Object>(ExecuteDoCloseLogonPopupCommand);
            ScriptEverythingCommand = new SimpleCommand<Object, Object>(ExecuteScriptEverythingCommand);
            ScriptDataCommand = new SimpleCommand<object, object>(ExecuteScriptDataCommand);
            ExitApplicationCommand = new SimpleCommand<object, object>(ExecuteExitApplicationCommand);
            ShowHelpPageCommand = new SimpleCommand<object, object>(ExecuteShowHelpPageCommand);

            ViewConnectionPropertiesCommand = new SimpleCommand<Object, Object>(ExecuteViewConnectionPropertiesCommand);


            DBObjectTypesList.Add(enumDatabaseObjectTypes.Table);
            DBObjectTypesList.Add(enumDatabaseObjectTypes.StoredProcedure);
            DBObjectTypesList.Add(enumDatabaseObjectTypes.View);
            DBObjectTypesList.Add(enumDatabaseObjectTypes.Trigger);

            timer_batchRequestsPerSecond = new DispatcherTimer();
        }

        private void _generateScriptsBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {   
            //Depending on which option is selected from the ribbon menu, script those objects.
            if (e.Argument.ToString() == enumDatabaseObjectTypes.Everything.ToString())
            {
                e.Result = cn.ScriptEverything(SelectedDB, new ObjectsToScriptOptions(true,true,true,true,true,true,true));                
            }

            if (e.Argument.ToString() == enumDatabaseObjectTypes.StoredProcedure.ToString())
            {
                e.Result = cn.ScriptEverything(SelectedDB, new ObjectsToScriptOptions(false,true, false,false, false, false, false));
            }

            if (e.Argument.ToString() == enumDatabaseObjectTypes.Indexes.ToString())
            {
                e.Result = cn.ScriptEverything(SelectedDB, new ObjectsToScriptOptions(false, false, false,true, false, false, false));
            }

            if (e.Argument.ToString() == enumDatabaseObjectTypes.ForeignKey.ToString())
            {
                e.Result = cn.ScriptEverything(SelectedDB, new ObjectsToScriptOptions(false, false,true, false, false, false, false));
            }

        }

        private void _generateScriptsBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw e.Error;
            }
            else
            {
                SQLScript = e.Result as string;

                if (cn.objectsToScriptOptions.ScriptTables)
                {
                    WorkspaceData workspace2 = new WorkspaceData("", "DisplayScriptView", SQLScript, "Tables", true);
                    Views.Add(workspace2);
                    SetActiveWorkspace(workspace2);
                    CreateRightClickContextMenus2();      
                }

                if (cn.objectsToScriptOptions.ScriptIndexes)
                {
                    WorkspaceData workspace3 = new WorkspaceData("", "DisplayScriptView", cn.SQLScriptIndexes, "Indexes", true);
                    Views.Add(workspace3);
                    SetActiveWorkspace(workspace3);                                
                }

                if (cn.objectsToScriptOptions.ScriptForeignKeys)
                {
                    WorkspaceData workspace4 = new WorkspaceData("", "DisplayScriptView", cn.SQLScriptForeignKeysDrop + Environment.NewLine + cn.SQLScriptForeignKeysAdd, "Foreign Keys", true);
                    Views.Add(workspace4);
                    SetActiveWorkspace(workspace4);                                
                }

                if (cn.objectsToScriptOptions.ScriptTriggers)
                {
                    WorkspaceData workspace5 = new WorkspaceData("", "DisplayScriptView", cn.SQLScriptTriggers, "Triggers", true);
                    Views.Add(workspace5);
                    SetActiveWorkspace(workspace5);                                
                }

                if (cn.objectsToScriptOptions.ScriptStoredProcs)
                {
                    WorkspaceData workspace6 = new WorkspaceData("", "DisplayScriptView", cn.SQLScriptStoredProcs, "Stored Procs", true);
                    Views.Add(workspace6);
                    SetActiveWorkspace(workspace6);                                
                }

                if (cn.objectsToScriptOptions.ScriptViews)
                {
                    WorkspaceData workspace7 = new WorkspaceData("", "DisplayScriptView", cn.SQLScriptViews, "Views", true);
                    Views.Add(workspace7);
                    SetActiveWorkspace(workspace7);                                
                }
                
                IsLoading = false;
            }
        }

        private void ViewAwareStatusService_ViewLoaded()
        {

            if (Designer.IsInDesignMode)
                return;

            WorkspaceData workspace1 = new WorkspaceData("","HomepageView",this.Views, "Home Page", false);            
            Views.Add(workspace1);

            SetActiveWorkspace(workspace1);
        }

        private void ExecuteDBSelectedCommand(EventToCommandArgs args)
        {
            SelectedDB = args.Sender as Database;

            SelectedDBObjectType = enumDatabaseObjectTypes.Table;
            SetExpandedList("TableList");
        }

        private void ExecuteSelectedObjectDoubleClickedCommand(EventToCommandArgs args)
        {
            SelectedObject  = args.Sender;

            WorkspaceData workspace;

            switch (SelectedDBObjectType)
            {
                case enumDatabaseObjectTypes.Table:
                    workspace = new WorkspaceData("", "TablesView", (Microsoft.SqlServer.Management.Smo.Table)SelectedObject, "T - " + ((Microsoft.SqlServer.Management.Smo.Table)SelectedObject).Name, true);
                    Views.Add(workspace);
                    SetActiveWorkspace(workspace);
                    break;

                case enumDatabaseObjectTypes.StoredProcedure:
                    workspace = new WorkspaceData("", "StoredProcsView", (StoredProcedure)SelectedObject, "SP - " + ((StoredProcedure)SelectedObject).Name, true);
                    Views.Add(workspace);
                    SetActiveWorkspace(workspace);
                    break;

                case enumDatabaseObjectTypes.View:
                    workspace = new WorkspaceData("", "DBViewsView", (View)SelectedObject, "VW - " + ((View)SelectedObject).Name, true);
                    Views.Add(workspace);
                    SetActiveWorkspace(workspace);
                    break;

                case enumDatabaseObjectTypes.Trigger:
                    workspace = new WorkspaceData("", "TriggersView", (Microsoft.SqlServer.Management.Smo.Trigger)SelectedObject, "TR - " + ((Microsoft.SqlServer.Management.Smo.Trigger)SelectedObject).Name, true);
                    Views.Add(workspace);
                    SetActiveWorkspace(workspace);
                    break;
                default:
                    break;
            }

        }

        private void ExecuteDoLogonCommand(Object args)
        {
            ConnectToDB();
        }

        private void ExecuteDoCloseLogonPopupCommand(Object args)
        {
            this.ShowServerConnectionPopup = false;
        }

        private void ExecuteDoDisconnectDBCommand(Object args)
        {
            if (DBServerConnectionSingleton.Instance.ActiveSQLServerConnection != null)
            {
                DBServerConnectionSingleton.Instance.DisconnectServer();
                DBList = null;
                SelectedDB = null;
                ListViewObjectList = null;
                TimerStop();
            }
        }

        private void ExecuteScriptEverythingCommand(Object args)
        {

            if (_SQLServer == null)
            {
                messageBoxService.ShowInformation("You haven't connected to a database server yet.");
                return;
            }

            if (SelectedDB == null)
            {
                messageBoxService.ShowInformation("Please select a database.");
            }
            else
            {
                if (!_generateScriptsBackgroundWorker.IsBusy)
                {
                    IsLoading = true;
                    _generateScriptsBackgroundWorker.RunWorkerAsync(args.ToString());
                }
            }
        }

        private void ExecuteScriptDataCommand(Object args)
        {
            Microsoft.SqlServer.Management.Smo.Table selectedTable = (Microsoft.SqlServer.Management.Smo.Table)args;

            WorkspaceData workspace = new WorkspaceData("", "ScriptTableDataView", selectedTable, "Data", true);
            Views.Add(workspace);
            SetActiveWorkspace(workspace);  

            ShowContextMenu = false;
        }

        private void ExecuteExitApplicationCommand(Object args)
        {
            DBServerConnectionSingleton.Instance.DisconnectServer();
            Application.Current.Shutdown();
        }

        private void ExecuteShowHelpPageCommand(Object args)
        {
            WorkspaceData workspace = new WorkspaceData("", "HelpPageView", null, "About Page", true);
            Views.Add(workspace);
            SetActiveWorkspace(workspace);

        }

        private void ExecuteViewConnectionPropertiesCommand(Object args)
        {
            ShowServerConnectionPopup = true;
        }

        private async void RefreshDBObjectsList()
        {
            cts = new CancellationTokenSource();
            cts.Cancel();
            IsLoading = true;
            ListViewObjectList = await Task.Factory.StartNew(() => RefreshDBObjectsListAsync());
            IsLoading = false;

        }

        private ObservableCollection<object> RefreshDBObjectsListAsync()
        {
            ObservableCollection<object> returnCollection;
            cn.SelectedDB = SelectedDB;
            
            returnCollection = new ObservableCollection<object>(cn.GetDBObjectList(SelectedDB.Name, SelectedDBObjectType));
            
            return returnCollection;
        }

        private async void ConnectToDB()
        {

            if ((DBServerConnectionSingleton.Instance.DBServerName != null && DBServerConnectionSingleton.Instance.UseIntegratedAuthentication) || (!DBServerConnectionSingleton.Instance.UseIntegratedAuthentication && DBServerConnectionSingleton.Instance.Username != "" && DBServerConnectionSingleton.Instance.Password != ""))
            {

                cts = new CancellationTokenSource();

                IsLoading = true;
                await Task.Factory.StartNew(() => ConnectToDBAsync());
                IsLoading = false;

                TimerStart_BatchRequestsPerSecond(3);
            }
        }

        private void ConnectToDBAsync()
        {
            try
            {
                if (DBServerConnectionSingleton.Instance.ConnectToSQLServer())

                _SQLServer = DBServerConnectionSingleton.Instance.ActiveSQLServerConnection;

                cn = new BusinessLogic();

                DBList = new ObservableCollection<Database>(cn.GetDatabasesList());

                DBListExpanded = true;

                SetExpandedList("DBList");

                ShowServerConnectionPopup = false;

            }
            catch (Microsoft.SqlServer.Management.Common.ConnectionFailureException exc)
            {
                //messageBoxService.ShowInformation(exc.InnerException.Message);
                messageBoxService.ShowInformation("Failed to connect. Please check : "
                    + Environment.NewLine + "1. The server name is corect."
                    + Environment.NewLine + "2. Username and password combination is correct."
                    + Environment.NewLine + "3. Select the correct authorised network protocol for your SQL Server.");
            }
        }

        private List<CinchMenuItem> CreateRightClickContextMenus2()
        {
            MainWindowOptions = null;

            if (SelectedDBObjectType == enumDatabaseObjectTypes.Table)
            {
                ShowContextMenu = true;

                List<CinchMenuItem> menu = new List<CinchMenuItem>();

                CinchMenuItem menuScriptData = new CinchMenuItem("Script Data");
                menuScriptData.Command = ScriptDataCommand;
                menu.Add(menuScriptData);

                MainWindowOptions = menu;

                return menu;
            }
            else
            {
                ShowContextMenu = false;
                MainWindowOptions = null;
                return null;
            }
        }


        private void SetExpandedList(string expandedItem)
        {
            DBListExpanded = false;

            switch (expandedItem)
            {
                case "DBList" :
                    DBListExpanded = true;
                    break;

                default:
                    break;
            }
        }

        private string GetApplicationVersionNumber()
        {
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.Reflection.Assembly _assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly();

                string ourVersion = string.Empty;

                //if running the deployed application, you can get the version
                //  from the ApplicationDeployment information. If you try
                //  to access this when you are running in Visual Studio, it will not work.
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    ourVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                }
                else
                {
                    if (_assemblyInfo != null)
                    {
                        ourVersion = _assemblyInfo.GetName().Version.ToString();
                    }
                }

                Console.WriteLine("Application version : " + ourVersion);
                return ourVersion;
            }
            catch (Exception exc)
            {
                return "N/A";
            }
        }

        #region Batch requests per second timer

        public void TimerStart_BatchRequestsPerSecond(int PeriodInSeconds)
        {
            timer_batchRequestsPerSecond.Interval = TimeSpan.FromSeconds(PeriodInSeconds);
            timer_batchRequestsPerSecond.Tick += timer_Task;
            timer_batchRequestsPerSecond.Start();
        }

        public void TimerStop()
        {
            timer_batchRequestsPerSecond.Stop();
        }

        private void timer_Task(object sender, EventArgs e)
        {
            Random rnd = new Random();            
            PerformanceMonitorValue = rnd.Next(0, 100);
        }

        #endregion

        #endregion

        #region Commands


        public SimpleCommand<Object, EventToCommandArgs> DBSelectedCommand { get; private set; }
        public SimpleCommand<Object, EventToCommandArgs> SelectedObjectDoubleClickedCommand { get; private set; }
        public SimpleCommand<object, object> DoDisconnectDBCommand { get; private set; }
        public SimpleCommand<object, object> DoLogonCommand { get; private set; }
        public SimpleCommand<object, object> DoCloseLogonPopupCommand { get; private set; }
        public SimpleCommand<object, object> ScriptEverythingCommand { get; private set; }
        public SimpleCommand<object, object> ViewConnectionPropertiesCommand { get; private set; }
        public SimpleCommand<object, object> ScriptDataCommand { get; private set; }
        public SimpleCommand<object, object> ExitApplicationCommand { get; private set; }
        public SimpleCommand<object, object> ShowHelpPageCommand { get; private set; }

        #endregion

        #region Public properties

        private ObservableCollection<Database> _DBList = new ObservableCollection<Database>();
        public ObservableCollection<Database> DBList 
        {
            get { return _DBList; }

            set
            {
                _DBList = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        private ObservableCollection<object> _objectList = new ObservableCollection<object>();
        public ObservableCollection<object> ListViewObjectList
        {
            get { return _objectList; }

            set
            {
                _objectList = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        private Database _SelectedDB;
        public Database SelectedDB
        {
            get { return _SelectedDB; }

            set
            {
                _SelectedDB = value;
                DBServerConnectionSingleton.Instance.SelectedDB = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
                NotifyPropertyChanged("IsDBSelected");
                
            }
        }

        public bool IsDBSelected
        {
            get { 
                    if (SelectedDB != null && SelectedDB.IsAccessible) 
                        {
                            return true;
                        } 
                    else 
                        return false; 
            }
        }

        private Microsoft.SqlServer.Management.Smo.Table _SelectedTable;
        public Microsoft.SqlServer.Management.Smo.Table SelectedTable
        {
            get { return _SelectedTable; }

            set
            {
                _SelectedTable = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        private object _SelectedObject;
        public object SelectedObject
        {
            get { return _SelectedObject; }

            set
            {
                _SelectedObject = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        private ObservableCollection<enumDatabaseObjectTypes> _DBObjectTypesList = new ObservableCollection<enumDatabaseObjectTypes>();
        public ObservableCollection<enumDatabaseObjectTypes> DBObjectTypesList
        {
            get { return _DBObjectTypesList; }

            set
            {
                _DBObjectTypesList = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        private enumDatabaseObjectTypes _SelectedDBObjectType;
        public enumDatabaseObjectTypes SelectedDBObjectType
        {
            get { return _SelectedDBObjectType; }

            set
            {
                SelectedObject = value;
                _SelectedDBObjectType = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());

                if (cts != null)
                {
                    cts.Cancel();
                }
                CreateRightClickContextMenus2();
                RefreshDBObjectsList();                
                
            }
        }
        
        private string _applicationName = "SQL Server Companion";
        public string ApplicationName
        {
            get { return _applicationName; }
            set
            {
                _applicationName = value;
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
 
        private bool _ShowServerConnectionPopup = false;
        public bool ShowServerConnectionPopup
        {
            get { return _ShowServerConnectionPopup; }
            set
            {
                _ShowServerConnectionPopup = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }


        /// <summary>
        /// Returns the bindbable Main Window options
        /// </summary>
        /// 
        private List<CinchMenuItem> _MainWindowOptions;
        public List<CinchMenuItem> MainWindowOptions
        {
            get
            {
                return _MainWindowOptions;                
            }
            set
            {
                _MainWindowOptions = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }


        /// <summary>
        /// ShowContextMenu
        /// </summary>
        static PropertyChangedEventArgs showContextMenuArgs = ObservableHelper.CreateArgs<MainWindowViewModel>(x => x.ShowContextMenu);

        public bool ShowContextMenu
        {
            get { return showContextMenu; }
            private set
            {
                showContextMenu = value;
                NotifyPropertyChanged(showContextMenuArgs);
            }
        }

        private int _PerformanceMonitorValue = 0;
        public int PerformanceMonitorValue
        {
            get { return _PerformanceMonitorValue; }
            set
            {
                _PerformanceMonitorValue = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }

        }

        public string DBServerName
        {
            get { return DBServerConnectionSingleton.Instance.DBServerName; }
            set
            {
                DBServerConnectionSingleton.Instance.DBServerName = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }

        }

        public string Username
        {
            get { return DBServerConnectionSingleton.Instance.Username; }
            set
            {
                DBServerConnectionSingleton.Instance.Username = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        public string Password
        {
            get { return DBServerConnectionSingleton.Instance.Password; }
            set
            {
                DBServerConnectionSingleton.Instance.Password = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        public bool UseSQLIntegratedAuthentication
        {
            get { return DBServerConnectionSingleton.Instance.UseIntegratedAuthentication; }
            set
            {
                DBServerConnectionSingleton.Instance.UseIntegratedAuthentication = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        public NetworkProtocol SelectedNetworkProtocol
        {
            get { return DBServerConnectionSingleton.Instance.SelectedNetworkProtocol; }
            set
            {
                DBServerConnectionSingleton.Instance.SelectedNetworkProtocol = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        public string ApplicationVersionNumber
        {
            get
            {
                return GetApplicationVersionNumber();
            }
        }

        #region Expander controls

        private bool _DBListExpanded = true;
        public bool DBListExpanded
        {
            get { return _DBListExpanded; }
            set
            {
                _DBListExpanded = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        #endregion

        #endregion

    }
}
