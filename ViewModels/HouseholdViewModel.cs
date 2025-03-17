using System.Collections.ObjectModel;
using Computer_Controlled_ManagementSystem.Models;
using HouseholdManagementSystem.Models;
using HouseholdManagementSystem.Repositories;
using HouseholdManagementSystem.ViewModels;

namespace HouseholdManagementSystem.ViewModels
{
    public class HouseholdViewModel : ObservableObject
    {
        private HouseholdRepository _householdRepository = new HouseholdRepository();
        public ObservableCollection<Household> Households { get; set; }

        public HouseholdViewModel()
        {
            Households = new ObservableCollection<Household>(_householdRepository.GetAllHouseholds());
        }
    }
}
