using APIforUpcomingProjects.DTOS.CarDTOs;
using APIforUpcomingProjects.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<NewCarDto, CarModel>();
        }
    }
}
