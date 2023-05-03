using System.ComponentModel.DataAnnotations;

namespace ApplicationDevelopment.Blazor.Data.DTO
{
    public class LoginData
    {
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
