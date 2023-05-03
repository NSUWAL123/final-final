namespace ApplicationDevelopment.Blazor.Data.DTO
{
    public class EditProfileData
    {
        public string UserId { get; set; }
        public string? UserName { get; set; }
        public AddressData? Address { get; set; }
        public string? LicensePhoto { get; set; }
        public string? CitizenshipPhoto { get; set; }
    }
}
