namespace ApplicationDevelopment.Blazor.Data.DTO
{
    public class OfferData
    {
        public Guid Id { get; set; }
        public string OfferTitle { get; set; }
        public string OfferDescription { get; set; }
        public DateTime OfferStart { get; set; }
        public DateTime OfferEnd { get; set; }
        public Guid CarId { get; set; }
    }
}
