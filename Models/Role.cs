using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<UserRole> UsersRoles { get; set; }
    }
}
