using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Application.DTOS
{
    public class CarDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Brand { get; set; } 
        public string Model { get; set; } 
        public string Year { get; set; } 
        public string Type { get; set; } 
        public int RetailFee { get; set; }
        public int Discount { get; set; }
        public bool IsAvailable { get; set; }
        public string Color { get; set; } 
        public string CarImage { get; set; }
    }
}
