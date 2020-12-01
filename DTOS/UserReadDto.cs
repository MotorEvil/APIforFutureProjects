using APIforUpcomingProjects.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.DTOS
{
    public class UserReadDto
    {
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }
    }
}
