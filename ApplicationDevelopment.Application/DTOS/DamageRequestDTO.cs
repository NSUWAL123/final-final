using ApplicationDevelopment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Application.DTOS
{
    public class DamageRequestDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CarRequestId { get; set; }
        public DamageType DamageType { get; set; }
        public string DamageDescription { get; set; } = string.Empty;
    }
}
