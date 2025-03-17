using System.Windows;
using HouseholdManagementSystem.ViewModels;

namespace HouseholdManagementSystem.Views
{
    public partial class InventoryView : Window
    {
        public InventoryView()
        {
            InitializeComponent();
            DataContext = new InventoryViewModel(); // Assign ViewModel
        }
    }
}
