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
using System.IO;
using SQLServerCompanion.HelperClasses;
using System.Reflection;

namespace SQLServerCompanion.ViewModels
{
    [ExportViewModel("DisplayScriptViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DisplayScriptViewModel : ViewModelBase
    {

        public IUIVisualizerService uiVisualizer;
        private IMessageBoxService messageBoxService;
        private IViewAwareStatus viewAwareStatusService;

        [ImportingConstructor]
        public DisplayScriptViewModel(IUIVisualizerService uiVisualizer, IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatusService)
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
            dlg.FileName = "DBScript"; // Default file name
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

        #region Properties

        private string _sqlScript = "";
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