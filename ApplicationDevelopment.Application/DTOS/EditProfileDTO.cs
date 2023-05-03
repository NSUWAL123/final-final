using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Application.DTOS
{
    public class EditProfileDto
    {

        public string UserId { get; set; }
        public string? UserName { get; set; }
        public AddressDTO? Address { get; set; }
        public string? LicensePhoto { get; set; }
        public string? CitizenshipPhoto { get; set; }
    }
}
