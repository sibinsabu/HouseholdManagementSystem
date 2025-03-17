using System;

namespace HouseholdManagementSystem.Models
{
    public class ServiceRecord
    {
        public int ServiceID { get; set; }
        public int HouseholdID { get; set; }
        public int TechnicianID { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Problem { get; set; }
        public string ActionTaken { get; set; }
        public string Status { get; set; } // Pending, In Progress, Completed
    }
}
