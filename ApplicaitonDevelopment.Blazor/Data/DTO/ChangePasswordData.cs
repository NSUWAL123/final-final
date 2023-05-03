using System.ComponentModel.DataAnnotations;

namespace ApplicationDevelopment.Blazor.Data.DTO
{
    public class ChangePasswordData
    {
        public string UserId { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
