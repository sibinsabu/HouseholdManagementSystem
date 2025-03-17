using System.Windows;
using HouseholdManagementSystem.ViewModels;

namespace HouseholdManagementSystem.Views
{
    public partial class ServiceRecordView : Window
    {
        public ServiceRecordView()
        {
            InitializeComponent();
            DataContext = new ServiceRecordViewModel(); // Assign ViewModel
        }
    }
}
