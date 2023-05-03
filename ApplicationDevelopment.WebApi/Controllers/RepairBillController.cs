using ApplicationDevelopment.Application.DTOS;
using ApplicationDevelopment.Domain.Entities;
using ApplicationDevelopment.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairBillController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RepairBillController (ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<RepairBillDTO>> PostRepairBill(RepairBillDTO repairBillDTO)
        {
            if (repairBillDTO == null)
            {
                return BadRequest("The repair bill object cannot be null.");
            }

            var repairBill = new RepairBill
            {
                Id = repairBillDTO.Id,
                DamageRequestId = repairBillDTO.DamageRequestId,
                RepairCost = repairBillDTO.RepairCost,
                IsPaid = repairBillDTO.IsPaid
            };

            _context.RepairBill.Add(repairBill);
            await _context.SaveChangesAsync();

            var newRepairBillDTO = new RepairBillDTO
            {
                Id = repairBill.Id,
                DamageRequestId = repairBill.DamageRequestId,
                RepairCost = repairBill.RepairCost,
                IsPaid = repairBill.IsPaid
            };

            return newRepairBillDTO;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairBillDTO>>> GetRepairBills()
        {
            var repairBills = await _context.RepairBill.ToListAsync();

            if (repairBills == null || !repairBills.Any())
            {
                return NotFound();
            }

            var damageRequestDTOs = repairBills.Select(rb => new RepairBillDTO
            {
                Id = rb.Id,
                DamageRequestId = rb.DamageRequestId,
                IsPaid = rb.IsPaid,
                RepairCost = rb.RepairCost
            });

            return Ok(damageRequestDTOs);
        }

        [HttpPut("/updatePaymentStatus/{id}")]
        public async Task<IActionResult> Approve(Guid id, Boolean isPaid)
        {
            var repairBillModel = await _context.RepairBill.FindAsync(id);

            if (repairBillModel == null)
            {
                return NotFound();
            }

            repairBillModel.IsPaid = isPaid;

            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
