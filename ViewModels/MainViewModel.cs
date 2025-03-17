using System.Collections.ObjectModel;
using System.Windows.Input;
using HouseholdManagementSystem.Models;
using HouseholdManagementSystem.Commands; // ✅ Ensure this is included!

namespace HouseholdManagementSystem.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ICommand LoadHouseholdsCommand { get; }
        public ICommand LoadTechniciansCommand { get; }
        public ICommand LoadInventoryCommand { get; }
        public ICommand LoadServiceRecordsCommand { get; }

        public MainViewModel()
        {
            LoadHouseholdsCommand = new RelayCommand(_ => LoadHouseholds());
            LoadTechniciansCommand = new RelayCommand(_ => LoadTechnicians());
            LoadInventoryCommand = new RelayCommand(_ => LoadInventory());
            LoadServiceRecordsCommand = new RelayCommand(_ => LoadServiceRecords());
        }

        private void LoadHouseholds()
        {
            // Load household data
        }

        private void LoadTechnicians()
        {
            // Load technician data
        }

        private void LoadInventory()
        {
            // Load inventory data
        }

        private void LoadServiceRecords()
        {
            // Load service record data
        }
    }
}
