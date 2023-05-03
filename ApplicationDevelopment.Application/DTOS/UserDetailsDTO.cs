using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Application.DTOS
{
    public class UserDetailsDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string? Phone { get; set; }
    
        public AddressDTO? Address { get; set; }
        public string? LicensePhoto { get; set; }
        public string? CitizenshipPhoto { get; set; }
    }
}
