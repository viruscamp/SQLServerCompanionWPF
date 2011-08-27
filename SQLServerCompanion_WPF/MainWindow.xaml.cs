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
using Microsoft.SqlServer.Management.Smo;

using Cinch;
using SQLServerCompanion.ViewModels;
using Fluent;
using System.Windows.Interactivity;
using Microsoft.Expression.Interactivity;

namespace SQLServerCompanion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            LblDayOfWeek.Content = DateTime.Now.DayOfWeek;
            LblDayNumber.Content = DateTime.Now.Day;
            LblMonth.Content = DateTime.Now.ToString("MMMM"); 
        }

    }
}
