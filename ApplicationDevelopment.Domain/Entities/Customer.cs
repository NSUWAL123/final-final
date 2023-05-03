using ApplicationDevelopment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }

        public string LicensePhoto { get; set; } = string.Empty;
        public string CitizenshipPhoto { get; set; } = string.Empty;


        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
 

    }
}
