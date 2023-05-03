using ApplicationDevelopment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Application.DTOS
{
    public class OfferDTO
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string OfferTitle { get; set; }
        public string OfferDescription { get; set; }
        public DateTime OfferStart { get; set; }
        public DateTime OfferEnd { get; set; }
        public Guid CarId { get; set; }

    }
}
