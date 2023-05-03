using ApplicationDevelopment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Domain.Entities
{
    public class RepairBill
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("DamageRequest")]
        public Guid DamageRequestId { get; set; }
        public int RepairCost { get; set; }
        public bool IsPaid { get; set; }
    }
}
