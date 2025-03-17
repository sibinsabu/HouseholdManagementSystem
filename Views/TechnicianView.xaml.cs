using System.Windows;
using HouseholdManagementSystem.ViewModels;

namespace HouseholdManagementSystem.Views
{
    public partial class TechnicianView : Window
    {
        public TechnicianView()
        {
            InitializeComponent();
            DataContext = new TechnicianViewModel(); // Assign ViewModel
        }
    }
}
