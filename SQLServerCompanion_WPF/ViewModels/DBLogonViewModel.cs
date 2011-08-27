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
using Microsoft.SqlServer.Management.Common;
using SQLServerCompanion.HelperClasses;
using System.Reflection;

namespace SQLServerCompanion.ViewModels
{
    [ExportViewModel("DBLogonViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DBLogonViewModel : ViewModelBase
    {

        public IUIVisualizerService uiVisualizer;
        private IMessageBoxService messageBoxService;
        private IViewAwareStatus viewAwareStatusService;

        [ImportingConstructor]
        public DBLogonViewModel(IUIVisualizerService uiVisualizer, IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatusService)
        {
            this.uiVisualizer = uiVisualizer;
            this.messageBoxService = messageBoxService;
            this.viewAwareStatusService = viewAwareStatusService;
            this.viewAwareStatusService.ViewLoaded += ViewAwareStatusService_ViewLoaded;

        }

        #region Methods

        private void ViewAwareStatusService_ViewLoaded()
        {
            if (!Designer.IsInDesignMode)
            {
                var view = viewAwareStatusService.View;
                IWorkSpaceAware workspaceData = (IWorkSpaceAware)view;               
            }
        }

        #endregion


    }
}
