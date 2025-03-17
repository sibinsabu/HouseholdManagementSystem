using System.Windows;
using HouseholdManagementSystem.ViewModels;

namespace HouseholdManagementSystem.Views
{
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel _viewModel;

        public LoginWindow()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
            DataContext = _viewModel;
        }

        // ✅ Add missing LoginButton_Click event handler
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = PasswordBox.Password;  // ✅ Get password manually
            _viewModel.Login();
        }
    }
}
