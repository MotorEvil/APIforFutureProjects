using APIforUpcomingProjects.Data;
using APIforUpcomingProjects.DTOS.CarDTOs;
using APIforUpcomingProjects.Helpers;
using APIforUpcomingProjects.Models;
using APIforUpcomingProjects.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.Controllers
{
    [Authorize(Roles =Role.Admin)]
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private IMapper _mapper;
        private AppDbContext _context;
        private ICarService _carService;

        public CarController(IMapper mapper, AppDbContext context, ICarService carService)
        {
            _mapper = mapper;
            _context = context;
            _carService = carService;
        }

        [HttpPost("NewCar")]
        public IActionResult NewCar([FromBody] NewCarDto model)
        {
            var car = _mapper.Map<CarModel>(model);

            try
            {
                _carService.NewCar(car);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("AllCars")]
        public IActionResult AllCars()
        {
            return Ok();
        }

        [HttpGet("CarsByTeam/{teamName}")]
        public IActionResult CarsByTeam(string teamName)
        {
            return Ok();
        }

        public IActionResult CarByIdAndTeam()
        {
            return Ok();
        }

        public IActionResult DeleteCar(int id)
        {
            return Ok();
        }




    }
}
