using ApplicationDevelopment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Domain.Entities
{
    public enum DamageType
    {
        Scratch,
        Dent,
        Severe
    }

    public class DamageRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid DamageRequestId { get; set; }
        [ForeignKey("CarRequest")]
        public Guid CarRequestId { get; set; }
        public virtual CarRequest CarRequest { get; set; }

        public DamageType DamageType { get; set; }
        public string DamageDescription { get; set; } = string.Empty;
    }
}
