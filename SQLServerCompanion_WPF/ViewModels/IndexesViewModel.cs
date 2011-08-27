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
using System.Reflection;
using SQLServerCompanion.HelperClasses;
using System.IO;

namespace SQLServerCompanion.ViewModels
{
    [ExportViewModel("IndexesViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class IndexesViewModel : ViewModelBase
    {

        public IUIVisualizerService uiVisualizer;
        private IMessageBoxService messageBoxService;
        private IViewAwareStatus viewAwareStatusService;

        [ImportingConstructor]
        public IndexesViewModel(IUIVisualizerService uiVisualizer, IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatusService)
        {
            this.uiVisualizer = uiVisualizer;
            this.messageBoxService = messageBoxService;
            this.viewAwareStatusService = viewAwareStatusService;
            this.viewAwareStatusService.ViewLoaded += ViewAwareStatusService_ViewLoaded;

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
                SQLScript = (string)workspaceData.WorkSpaceContextualData.DataValue;
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
            dlg.FileName = "IndexesScript"; // Default file name
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

        private Database _SelectedDB;
        public Database SelectedDB
        {
            get { return _SelectedDB; }

            set
            {
                _SelectedDB = value;
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

        #endregion


    }//class
}//namespace