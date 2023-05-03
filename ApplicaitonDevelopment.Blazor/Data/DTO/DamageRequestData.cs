namespace ApplicationDevelopment.Blazor.Data.DTO
{
    public enum DamageType
    {
        Scratch,
        Dent,
        Severe
    }
    public class DamageRequestData
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CarRequestId { get; set; }
        public DamageType DamageType { get; set; }
        public string DamageDescription { get; set; } = string.Empty;
    }
}
