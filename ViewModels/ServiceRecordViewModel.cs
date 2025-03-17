using System.Collections.ObjectModel;
using HouseholdManagementSystem.Models;
using HouseholdManagementSystem.Repositories;
using HouseholdManagementSystem.ViewModels;

namespace HouseholdManagementSystem.ViewModels
{
    public class ServiceRecordViewModel : ObservableObject
    {
        private ServiceRecordRepository _serviceRecordRepository = new ServiceRecordRepository();
        private ObservableCollection<ServiceRecord> _serviceRecords;

        public ObservableCollection<ServiceRecord> ServiceRecords
        {
            get => _serviceRecords;
            set => SetProperty(ref _serviceRecords, value); // ✅ Ensures UI updates correctly
        }

        public ServiceRecordViewModel()
        {
            ServiceRecords = new ObservableCollection<ServiceRecord>(_serviceRecordRepository.GetAllServiceRecords());
        }
    }
}
