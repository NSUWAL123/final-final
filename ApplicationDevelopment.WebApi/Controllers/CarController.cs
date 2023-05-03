//using ApplicationDevelopment.Application.Common.Interfaces;
//using ApplicationDevelopment.Application.DTOS;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace ApplicationDevelopment.WebApi.Controllers
//{
//    [ApiController]
//    public class CarController:ControllerBase
//    {
//        public async Task
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDevelopment.Application.DTOS;
using ApplicationDevelopment.Domain.Entities;
using ApplicationDevelopment.Infrastructure.Persistence;
using ApplicationDevelopment.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HajurKoCarRental_backend.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly CloudinaryService _cloudinaryService;

        public CarsController(ApplicationDbContext context, CloudinaryService cloudinaryService )
        {
            _context = context;
            _cloudinaryService = cloudinaryService; 
        }

        // GET: api/Cars
        //[Authorize]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        //{
        //    if (_context.Car == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.Car.ToListAsync();
        //}
        [HttpGet]
        public async Task<IEnumerable<CarDTO>> GetRentals()
        {
            var cars = await _context.Car.ToListAsync();

            var carDTOs = cars.Select(car => new CarDTO
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,  
                Year = car.Year,
                Type = car.Type,
                RetailFee = car.RetailFee,
                Discount = car.Discount,
                IsAvailable = car.IsAvailable,
                Color = car.Color,
                CarImage = car.CarImage,
            });

            return carDTOs;
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarsModel(Guid id)
        {
            if (_context.Car == null)
            {
                return NotFound();
            }
            var carsModel = await _context.Car.FindAsync(id);

            if (carsModel == null)
            {
                return NotFound();
            }

            return carsModel;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarsModel(Guid id, Car carsModel)
        {
            if (id != carsModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(carsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarsModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCarsModel(Car carsModel)
        {
            if (_context.Car == null)
            {
                return Problem("Entity set 'AppDataContext.Cars'  is null.");
            }

            var carImageUrl = await _cloudinaryService.UploadCar(carsModel.CarImage);

            Car newCar = new Car
            {
 
                Brand = carsModel.Brand,
                CarImage = carImageUrl,
                Color = carsModel.Color,
                Discount = carsModel.Discount,
                IsAvailable = carsModel.IsAvailable,
                Model = carsModel.Model,
                RetailFee = carsModel.RetailFee,
                Type = carsModel.Type,
                Year = carsModel.Year,
            };
            
            _context.Car.Add(newCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarsModel", new { id = carsModel.Id }, carsModel);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarsModel(Guid id)
        {
            if (_context.Car == null)
            {
                return NotFound();
            }
            var carsModel = await _context.Car.FindAsync(id);
            if (carsModel == null)
            {
                return NotFound();
            }

            _context.Car.Remove(carsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarsModelExists(Guid id)
        {
            return (_context.Car?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
