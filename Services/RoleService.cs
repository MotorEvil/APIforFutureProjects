using APIforUpcomingProjects.Data;
using APIforUpcomingProjects.DTOS;
using APIforUpcomingProjects.Helpers;
using APIforUpcomingProjects.Models;
using APIforUpcomingProjects.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.Services
{
    public class RoleService : IRoleService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public RoleService(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Role CreateRole(Role role)
        {
            if (_context.Roles.Any(x => x.Name == role.Name))
                throw new AppException("Role name \"" + role.Name + "\" is already taken");

            _context.Roles.Add(role);
            _context.SaveChanges();

            return role;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles;
        }

        // Need implementation
/*        public Role GetRoleById(int id)
        {
            return _context.Roles.Find(id);
        }
*/
        public void DeleteRole(int id)
        {
            var role = _context.Roles.Find(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }
    }
}
