using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationDevelopment.Infrastructure.Persistence;
using ApplicationDevelopment.Domain.Entities;
using ApplicationDevelopment.Application.DTOS;

namespace ApplicationDevelopment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamagedCarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DamagedCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DamageRequestDTO>>> GetDamageRequests()
        {
            var damageRequests = await _context.DamageRequest.ToListAsync();

            if (damageRequests == null || !damageRequests.Any())
            {
                return NotFound();
            }

            var damageRequestDTOs = damageRequests.Select(dr => new DamageRequestDTO
            {
                Id = dr.Id,
                CarRequestId = dr.CarRequestId,
                DamageType = dr.DamageType,
                DamageDescription = dr.DamageDescription
            });

            return Ok(damageRequestDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DamageRequestDTO>> GetDamageRequest(Guid id)
        {
            var damageRequest = await _context.DamageRequest.FindAsync(id);

            if (damageRequest == null)
            {
                return NotFound("The damage request with the specified ID was not found.");
            }

            var damageRequestDTO = new DamageRequestDTO
            {
                Id = damageRequest.Id,
                CarRequestId = damageRequest.CarRequestId,
                DamageType = damageRequest.DamageType,
                DamageDescription = damageRequest.DamageDescription
            };

            return damageRequestDTO;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DamageRequestDTO>> PutDamageRequest(Guid id, DamageRequestDTO damageRequestDTO)
        {
            if (damageRequestDTO == null)
            {
                return BadRequest();
            }

            var damageRequest = await _context.DamageRequest.FindAsync(id);

            if (damageRequest == null)
            {
                return NotFound("The damage request with the specified ID was not found.");
            }

            damageRequest.CarRequestId = damageRequestDTO.CarRequestId;
            damageRequest.DamageType = damageRequestDTO.DamageType;
            damageRequest.DamageDescription = damageRequestDTO.DamageDescription;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DamagedCarsModelExists(id))
                {
                    return NotFound("The damage request with the specified ID was not found.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(damageRequestDTO);
        }

        [HttpPost]
        public async Task<ActionResult<DamageRequestDTO>> PostDamageRequest(DamageRequestDTO damageRequestDTO)
        {
            if (damageRequestDTO == null)
            {
                return BadRequest("The damage request object cannot be null.");
            }

            var damageRequest = new DamageRequest
            {
                Id = damageRequestDTO.Id,
                CarRequestId = damageRequestDTO.CarRequestId,
                DamageType = damageRequestDTO.DamageType,
                DamageDescription = damageRequestDTO.DamageDescription
            };

            _context.DamageRequest.Add(damageRequest);
            await _context.SaveChangesAsync();

            var newDamageRequestDTO = new DamageRequestDTO
            {
                Id = damageRequest.Id,
                CarRequestId = damageRequest.CarRequestId,
                DamageType = damageRequest.DamageType,
                DamageDescription = damageRequest.DamageDescription
            };

            return  newDamageRequestDTO;
        }


        // DELETE: api/DamagedCars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDamagedCarsModel(Guid id)
        {
            if (_context.DamageRequest == null)
            {
                return NotFound();
            }
            var damagedCarsModel = await _context.DamageRequest.FindAsync(id);
            if (damagedCarsModel == null)
            {
                return NotFound();
            }

            _context.DamageRequest.Remove(damagedCarsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DamagedCarsModelExists(Guid id)
        {
            return (_context.DamageRequest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

