using Multi_Entity_Management_Tool;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Multi_Entity_Management_Tool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationView app = new ApplicationView();
            ApplicationViewModel context = new ApplicationViewModel();
            app.DataContext = context;
            app.Show();
        }
    }



//TODO: Assign Single Entity
//TODO: Assign Multiple Entities
//TODO: Remove Single Entity
//TODO: Remove Multiple Entities
//TODO: Load in SQL Queries
//TODO: Edit SQL Queries
//TODO: Syntax Highlighting for SQL
//TODO: Encrypt SQL Queries
//TODO: Decrypt SQL Queries
//TODO: Select different environments(Dev/Test/Prod)

}
