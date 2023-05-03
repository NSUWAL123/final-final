using ApplicationDevelopment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Domain.Entities
{

    public enum RequestStatus
    {
        Pending,
        Approved,
        Declined
    }

    // Payment medium can be either Online or Physical
    public enum PaymentMedium
    {
        Online,
        Physical
    }

    public class CarRequest 
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Car")]
        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }

        public string? StaffId { get; set; }
        public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PaymentMedium? PaymentMedium { get; set; }
        public bool IsPaid { get; set; }
    }
}

//staff table
//1. stf01 admin
//2. stf02 staff