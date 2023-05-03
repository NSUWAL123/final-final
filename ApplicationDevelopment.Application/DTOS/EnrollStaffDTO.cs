using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Application.DTOS
{
    public class EnrollStaffDTO
    {

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public AddressDTO? Address { get; set; }

    }
}
