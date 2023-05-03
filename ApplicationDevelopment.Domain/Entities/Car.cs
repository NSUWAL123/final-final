using ApplicationDevelopment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Domain.Entities
{
    public class Car 
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int RetailFee { get; set; }
        public int Discount { get; set; }
        public bool IsAvailable { get; set; }
        public string Color { get; set; } = string.Empty;
        public string? CarImage { get; set; }   
    }
}
