using APIforUpcomingProjects.DTOS;
using APIforUpcomingProjects.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<NewRoleDto, Role>();
            CreateMap<Role, RoleReadDto>();
        }
    }
}
