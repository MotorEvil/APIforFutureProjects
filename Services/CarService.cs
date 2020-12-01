using APIforUpcomingProjects.Data;
using APIforUpcomingProjects.Helpers;
using APIforUpcomingProjects.Models;
using APIforUpcomingProjects.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.Services
{
    public class CarService : ICarService
    {
        private AppDbContext _context;

        public CarService(AppDbContext context)
        {
            _context = context;
        }

        public CarModel NewCar(CarModel car)
        {
            if (_context.Cars.Any(x => x.LicenceNumber == car.LicenceNumber))
            {
                throw new AppException("Car with this" + car.LicenceNumber + "licence plate, already exists.");
            }

            _context.Cars.Add(car);
            _context.SaveChanges();

            return car;
        }

    }
}
