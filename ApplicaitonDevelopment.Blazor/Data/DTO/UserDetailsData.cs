namespace ApplicationDevelopment.Blazor.Data.DTO
{
	public class UserData
	{
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public AddressData? Address { get; set; }
        public string? LicensePhoto { get; set; }
        public string? CitizenshipPhoto { get; set; }
    }
}
