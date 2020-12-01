using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.DTOS.CarDTOs
{
    public class NewCarDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LicenceNumber { get; set; }
        [Required]
        public int MileageInKm { get; set; }
        [Required]
        public int MileageInKmAtRegistration { get; set; }
        [Required]
        public int ManufactureYear { get; set; }
        [Required]
        public int GasFor100km { get; set; }
        [Required]
        public int GasTankSize { get; set; }
        [Required]
        public string GasType { get; set; }
        [Required]
        public string GasCardNumber { get; set; }
        [Required]
        public int GasCardPin { get; set; }
        [Required]
        public string UserTeamName { get; set; }

    }
}
