﻿using APIforUpcomingProjects.Data;
using APIforUpcomingProjects.Helpers;
using APIforUpcomingProjects.Models;
using APIforUpcomingProjects.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.Services
{
    public class RoleService : IRoleService
    {
        private AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        public Role CreateRole(Role role)
        {
            if (_context.Roles.Any(x => x.Name == role.Name))
                throw new AppException("Role name \"" + role.Name + "\" is already taken");

            _context.Roles.Add(role);
            _context.SaveChanges();

            return role;
        }
    }
}