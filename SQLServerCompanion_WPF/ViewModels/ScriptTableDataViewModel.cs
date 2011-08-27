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
using System.Collections.Specialized;
using SQLServerCompanion.HelperClasses;
using System.Reflection;
using System.IO;

namespace SQLServerCompanion.ViewModels
{

    [ExportViewModel("ScriptTableDataViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScriptTableDataViewModel : ViewModelBase
    {
        public IUIVisualizerService uiVisualizer;
        private IMessageBoxService messageBoxService;
        private IViewAwareStatus viewAwareStatusService;
        private BackgroundWorker _backgroundWorker;

        [ImportingConstructor]
        public ScriptTableDataViewModel(IUIVisualizerService uiVisualizer, IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatusService)
        {
            this.uiVisualizer = uiVisualizer;
            this.messageBoxService = messageBoxService;
            this.viewAwareStatusService = viewAwareStatusService;
            this.viewAwareStatusService.ViewLoaded += ViewAwareStatusService_ViewLoaded;

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;

            //Commands
            DoCopyToClipboardCommand = new SimpleCommand<Object, Object>(ExecuteDoCopyToClipboardCommand);
            DoSaveAsCommand = new SimpleCommand<Object, Object>(ExecuteDoSaveAsCommand);

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

            BusinessLogic cn = new BusinessLogic();
            sqlScript = cn.ScriptTableData(SelectedTable);
            ScriptFilePath = cn.CurrentDirectoryPath + @"\DataScript_" + SelectedTable.Name + ".sql";
            e.Result = sqlScript;
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw e.Error;
                }
                else
                {
                    SQLScript = e.Result as string;
                    IsLoading = false;                    
                }
            }
            catch (Exception )
            {
                throw ;
            }
        }

        private void ExecuteDoCopyToClipboardCommand(Object args)
        {
            System.Windows.Clipboard.SetText(SQLScript);
        }

        private void ExecuteDoSaveAsCommand(Object args)
        {
            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "DataScript_" + SelectedTable; // Default file name
            dlg.DefaultExt = ".sql"; // Default file extension
            dlg.Filter = "SQL query (.sql)|*.sql| Text documents (.txt)|*.txt "; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                StreamWriter sw = new StreamWriter(filename);

                sw.Write(SQLScript);
                sw.Close();
                sw.Dispose();

                messageBoxService.ShowInformation("File saved.");
            }
        }
        #endregion


        #region Commands

        public SimpleCommand<object, object> DoCopyToClipboardCommand { get; private set; }
        public SimpleCommand<object, object> DoSaveAsCommand { get; private set; }

        #endregion

        #region Public properties

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


        private Table _selectedTable;
        public Table SelectedTable
        {
            get { return _selectedTable; }
            set
            {
                _selectedTable = value;
            }

        }

        private string _sqlScript;
        public string SQLScript
        {
            get { return _sqlScript; }
            set
            {
                _sqlScript = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }        

        private string _scriptFilePath;
        public string ScriptFilePath
        {
            get { return _scriptFilePath; }
            set
            {
                _scriptFilePath = value;
                NotifyPropertyChanged(MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        #endregion

    }//class
}//namespace
