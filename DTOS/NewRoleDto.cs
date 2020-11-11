using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.DTOS
{
    public class NewRoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}
