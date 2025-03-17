using System.Collections.ObjectModel;
using HouseholdManagementSystem.Models;
using HouseholdManagementSystem.Repositories;
using HouseholdManagementSystem.ViewModels;

namespace HouseholdManagementSystem.ViewModels
{
    public class TechnicianViewModel : ObservableObject
    {
        private TechnicianRepository _technicianRepository = new TechnicianRepository();
        public ObservableCollection<Technician> Technicians { get; set; }

        public TechnicianViewModel()
        {
            Technicians = new ObservableCollection<Technician>(_technicianRepository.GetAllTechnicians());
        }
    }
}
