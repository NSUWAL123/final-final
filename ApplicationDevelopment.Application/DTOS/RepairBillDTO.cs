using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Application.DTOS
{
    public class RepairBillDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid DamageRequestId { get; set; }
        public int RepairCost { get; set; }
        public bool IsPaid { get; set; }
    }
}
