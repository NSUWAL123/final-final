namespace ApplicationDevelopment.Blazor.Data.DTO
{
    public class CarData
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public int RetailFee { get; set; }
        public int Discount { get; set; }
        public bool IsAvailable { get; set; }
        public string Color { get; set; }
        public string CarImage { get; set; }
    }
}
