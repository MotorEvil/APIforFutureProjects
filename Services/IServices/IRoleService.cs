﻿using APIforUpcomingProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.Services.IServices
{
    public interface IRoleService
    {
        public Role CreateRole(Role role);
    }
}