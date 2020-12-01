using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenceNumber { get; set; }
        public int MileageInKm { get; set; }
        public int MileageInKmAtRegistration { get; set; }
        public int ManufactureYear { get; set; }
        public bool InUse { get; set; }
        public int GasFor100km { get; set; }
        public int GasTankSize { get; set; }
        public string GasType { get; set; }
        public string GasCardNumber { get; set; }
        public int GasCardPin { get; set; }
        public string UserTeamName { get; set; }

    }
}
