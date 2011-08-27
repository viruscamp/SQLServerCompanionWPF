using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.ComponentModel.Composition.Hosting;
using SQLServerCompanion.HelperClasses;

using Cinch;
using System.Reflection;
using MEFedMVVM.ViewModelLocator;
using System.Windows.Threading;

namespace SQLServerCompanion
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IMessageBoxService messageBoxService;

        #region Initialisation
        /// <summary>
        /// Initiliase Cinch using the CinchBootStrapper. 
        /// </summary>
        public App()
        {            
            CinchBootStrapper.Initialise(new List<Assembly> { typeof(App).Assembly });
            messageBoxService = new Cinch.WPFMessageBoxService();
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {         
            
            DBServerConnectionSingleton.Instance.Initialise();
            DispatcherUnhandledException += App_DispatcherUnhandledException;

        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            SQLServerCompanion.Properties.Settings.Default.SQLServerName = DBServerConnectionSingleton.Instance.DBServerName;
            SQLServerCompanion.Properties.Settings.Default.SQLUsername = DBServerConnectionSingleton.Instance.Username;
            SQLServerCompanion.Properties.Settings.Default.SQLPassword = DBServerConnectionSingleton.Instance.Password;
            SQLServerCompanion.Properties.Settings.Default.UseIntegratedAuthentication = DBServerConnectionSingleton.Instance.UseIntegratedAuthentication;
            SQLServerCompanion.Properties.Settings.Default.NetworkProtocol = DBServerConnectionSingleton.Instance.SelectedNetworkProtocol;
            SQLServerCompanion.Properties.Settings.Default.Save();

        }

        /// <summary>
        /// Occurs when an un handled Exception occurs for the Dispatcher
        /// </summary>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {            
            Exception ex = e.Exception;

            messageBoxService.ShowError("Application error : " + ex.Message);

            e.Handled = true;
        }

        #endregion

    }
}
