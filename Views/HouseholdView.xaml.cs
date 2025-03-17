using System.Windows;
using HouseholdManagementSystem.ViewModels;

namespace HouseholdManagementSystem.Views
{
    public partial class HouseholdView : Window
    {
        public HouseholdView()
        {
            InitializeComponent();
            DataContext = new HouseholdViewModel(); // Manually assign ViewModel
        }
    }
}
