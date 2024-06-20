namespace DiamondShopSystem.Business.Dtos
{
    public class QueryOrderDetailsDto
    {
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public string? ShipmentTrackingNumber { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public int? ProductId { get; set; }
    }
}
