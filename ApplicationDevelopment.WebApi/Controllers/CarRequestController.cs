//namespace ApplicationDevelopment.WebApi.Controllers
//{
//    public class CarRequestController
//    {
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ApplicationDevelopment.Infrastructure.Persistence;
using ApplicationDevelopment.Domain.Entities;
using ApplicationDevelopment.Application.DTOS;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApplicationDevelopment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RentalController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<CarRequestDTO>> GetRentals()
        {
            var rentals = await _context.CarRequest.ToListAsync();

            var rentalDTOs = rentals.Select(rental => new CarRequestDTO
            {
                UserId = rental.UserId,
                CarId = rental.CarId,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                IsPaid = rental.IsPaid, 
                PaymentMedium = rental.PaymentMedium,   
                RequestStatus = rental.RequestStatus,
                StaffId = rental.StaffId
            });

            return rentalDTOs;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarRequestDTO>> GetRentalModel(Guid id)
        {
            var rentalModel = await _context.CarRequest.FindAsync(id);

            if (rentalModel == null)
            {
                return NotFound();
            }

            var rentalDTO = new CarRequestDTO
            {
                UserId = rentalModel.UserId,
                CarId = rentalModel.CarId,
                StaffId = rentalModel.StaffId,
                RequestStatus = rentalModel.RequestStatus,
                StartDate = rentalModel.StartDate,
                EndDate = rentalModel.EndDate,
                PaymentMedium = rentalModel.PaymentMedium,
                IsPaid = rentalModel.IsPaid
            };

            return rentalDTO;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CarRequestDTO>> PutRentalModel(Guid id, CarRequestDTO currentRequest)
        {
            if (currentRequest == null)
            {
                return BadRequest();
            }

            var rentalModel = await _context.CarRequest.FindAsync(id);

            if (rentalModel == null)
            {
                return NotFound();
            }

            rentalModel.UserId = currentRequest.UserId;
            rentalModel.CarId = currentRequest.CarId;
            rentalModel.StaffId = currentRequest.StaffId;
            rentalModel.RequestStatus = currentRequest.RequestStatus;
            rentalModel.StartDate = currentRequest.StartDate;
            rentalModel.EndDate = currentRequest.EndDate;
            rentalModel.PaymentMedium = currentRequest.PaymentMedium;
            rentalModel.IsPaid = currentRequest.IsPaid;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(currentRequest);
        }

        [HttpPut("/approve/{id}")]
        public async Task<IActionResult> Approve(Guid id, RequestStatus status)
        {
            var rentalModel = await _context.CarRequest.FindAsync(id);

            if (rentalModel == null)
            {
                return NotFound();
            }

            rentalModel.RequestStatus = status;

            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult<CarRequestDTO>> PostRentalModel(CarRequestDTO rentalModel)
        {
            if (_context.CarRequest == null)
            {
                return Problem("Entity set 'AppDataContext.Rentals'  is null.");
            }

            CarRequest carRequest = new CarRequest()
            {
                CarId = rentalModel.CarId,
                UserId = rentalModel.UserId,
                //StaffId = rentalModel.StaffId,
                EndDate = rentalModel.EndDate,
                StartDate = rentalModel.StartDate,
                IsPaid = rentalModel.IsPaid,
                //PaymentMedium = rentalModel.PaymentMedium,
                RequestStatus = rentalModel.RequestStatus,
            };

            //rentalModel.discount_percentage = UserData(rentalModel);
            await _context.CarRequest.AddAsync(carRequest);
            await _context.SaveChangesAsync();

            return rentalModel;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalModel(Guid id)
        {
            if (_context.CarRequest == null)
            {
                return NotFound();
            }

            var rentalModel = await _context.CarRequest.FindAsync(id);
            if (rentalModel == null)
            {
                return NotFound();
            }

            _context.Remove(rentalModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool RentalModelExists(Guid id)
        {
            return (_context.CarRequest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}