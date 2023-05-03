using System.ComponentModel.DataAnnotations;

namespace ApplicationDevelopment.Blazor.Data.DTO
{
    public class RegisterData
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Phone { get; set; }

        public AddressData? Address { get; set; }
    }
}
