using System.Windows;
using HouseholdManagementSystem.Repositories;
using HouseholdManagementSystem.Views;

namespace HouseholdManagementSystem.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private string _username;
        private string _password;
        private readonly AdminRepository _adminRepository;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public LoginViewModel()
        {
            _adminRepository = new AdminRepository();
        }

        // 🔥 Change `private` to `public` to make it accessible in `LoginWindow.xaml.cs`
        public void Login()
        {
            if (_adminRepository.ValidateUser(Username, Password))
            {
                MessageBox.Show("Login successful!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.Windows[0]?.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
