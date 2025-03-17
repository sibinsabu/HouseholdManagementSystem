using System;
using System.Windows;
using HouseholdManagementSystem.Models;
using HouseholdManagementSystem.ViewModels;
using HouseholdManagementSystem.Views;

namespace HouseholdManagementSystem
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize the database
            DatabaseManager dbManager = new DatabaseManager();

            // Set up the main window
            MainWindow window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();
        }
    }
}
