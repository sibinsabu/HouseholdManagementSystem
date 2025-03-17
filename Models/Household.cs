using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Controlled_ManagementSystem.Models
{
    public class Household
    {
        public int HouseholdID { get; set; }  // Unique identifier
        public string OwnerName { get; set; }  // Household owner’s name
        public string Address { get; set; }  // Physical address
        public string ContactNum { get; set; }  // Contact number
        public DateTime InstalDate { get; set; }  // Installation date
        public DateTime LastInspect { get; set; }  // Last inspection date
    }
}
