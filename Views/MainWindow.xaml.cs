using System.Windows;
using HouseholdManagementSystem.Views;

namespace HouseholdManagementSystem.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenHouseholdView(object sender, RoutedEventArgs e)
        {
            HouseholdView householdView = new HouseholdView();
            householdView.Show();
        }

        private void OpenTechnicianView(object sender, RoutedEventArgs e)
        {
            TechnicianView technicianView = new TechnicianView();
            technicianView.Show();
        }

        private void OpenInventoryView(object sender, RoutedEventArgs e)
        {
            InventoryView inventoryView = new InventoryView();
            inventoryView.Show();
        }

        private void OpenServiceRecordView(object sender, RoutedEventArgs e)
        {
            ServiceRecordView serviceRecordView = new ServiceRecordView();
            serviceRecordView.Show();
        }

        // ✅ Fix: Add the missing LogoutButton_Click method
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logging out...");

            // Open Login Window
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            // Close Main Window
            this.Close();
        }
    }
}
