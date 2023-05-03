using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDevelopment.Domain.Entities
{
    public class Offer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string OfferTitle { get; set; }
        public string OfferDescription { get; set; }
        public DateTime OfferStart { get; set; }
        public DateTime OfferEnd { get; set; }

        [ForeignKey("Car")]
        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
