namespace ApplicationDevelopment.Blazor.Data.DTO
{
    public enum RequestStatus
    {
        Pending,
        Approved,
        Declined
    }

    // Payment medium can be either Online or Physical
    public enum PaymentMedium
    {
        Online,
        Physical
    }
    public class CarRequestData
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public Guid CarId { get; set; }
        public string? StaffId { get; set; }
        public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PaymentMedium? PaymentMedium { get; set; }
        public bool IsPaid { get; set; } = false;
    }
}
