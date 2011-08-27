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
using System.Reflection;
using SQLServerCompanion.HelperClasses;
using System.IO;

namespace SQLServerCompanion.ViewModels
{
    [ExportViewModel("StoredProcsViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StoredProcsViewModel : ViewModelBase
    {
        public IUIVisualizerService uiVisualizer;
        private IMessageBoxService messageBoxService;
        private IViewAwareStatus viewAwareStatusService;
        private BackgroundWorker _backgroundWorker;

        [ImportingConstructor]
        public StoredProcsViewModel(IUIVisualizerService uiVisualizer, IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatusService)
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
                SelectedSP = (StoredProcedure)workspaceData.WorkSpaceContextualData.DataValue;

                _backgroundWorker.RunWorkerAsync();
            }
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string sqlScript = "";
            string dropScript = "";

            StringBuilder resultScript = new StringBuilder(string.Empty);
            StringCollection coll = null;
            ScriptingOptions options = new ScriptingOptions();

            IsLoading = true;


            //First script the DROP
            options.ScriptDrops = true;
            options.IncludeHeaders = true;
            options.IncludeIfNotExists = true;
            coll = SelectedSP.Script(options);

            resultScript = new StringBuilder(string.Empty);

            foreach (string str in coll)
            {
                resultScript.Append(str);
                resultScript.Append(Environment.NewLine);
            }

            dropScript = resultScript.ToString();
            dropScript += "GO";

            //Script the CREATE statement
            resultScript = new StringBuilder(string.Empty);

            coll = SelectedSP.Script();

            foreach (string str in coll)
            {
                string tmpString = str;
                tmpString = tmpString.Replace("SET ANSI_NULLS ON", string.Empty);
                tmpString = tmpString.Replace("SET QUOTED_IDENTIFIER ON", string.Empty);

                resultScript.Append(tmpString);
                resultScript.Append(Environment.NewLine);
            }

            sqlScript += dropScript;
            sqlScript += resultScript.ToString();
            sqlScript += "GO";
            sqlScript += Environment.NewLine;
            sqlScript += Environment.NewLine;


            e.Result = sqlScript;
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
                IsLoading = false;
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
            dlg.FileName = "SP_" + SelectedSP; // Default file name
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


        private StoredProcedure _selectedSP;
        public StoredProcedure SelectedSP
        {
            get { return _selectedSP; }
            set
            {
                _selectedSP = value;
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

        #endregion

    }//class
}//namespace

