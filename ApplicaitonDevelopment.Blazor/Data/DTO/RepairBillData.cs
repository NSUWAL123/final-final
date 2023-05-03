namespace ApplicationDevelopment.Blazor.Data.DTO
{
    public class RepairBillData
    {
        public Guid Id { get; set; }
        public Guid DamageRequestId { get; set; }
        public int RepairCost { get; set; }
        public bool IsPaid { get; set; }
    }
}
