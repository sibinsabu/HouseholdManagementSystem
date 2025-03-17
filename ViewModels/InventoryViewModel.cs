using System.Collections.ObjectModel;
using HouseholdManagementSystem.Models;
using HouseholdManagementSystem.Repositories;
using HouseholdManagementSystem.ViewModels;

namespace HouseholdManagementSystem.ViewModels
{
    public class InventoryViewModel : ObservableObject
    {
        private InventoryRepository _inventoryRepository = new InventoryRepository();
        public ObservableCollection<InventoryItem> Inventory { get; set; }

        public InventoryViewModel()
        {
            Inventory = new ObservableCollection<InventoryItem>(_inventoryRepository.GetAllItems());
        }
    }
}
