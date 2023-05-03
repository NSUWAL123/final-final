using ApplicationDevelopment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ApplicationDevelopment.Application.DTOS
{
    public class CarRequestDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public Guid CarId { get; set; }
        public string? StaffId { get; set; }
        public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PaymentMedium? PaymentMedium { get; set; }
        public bool IsPaid { get; set; } = false;
    }
}