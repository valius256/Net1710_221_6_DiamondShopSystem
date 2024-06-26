namespace DiamondShopSystem.Business.Dtos
{
    public class QueryOrderDto
    {
        public int? OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; } = string.Empty;

        public string DeliveryStatus { get; set; } = string.Empty;

        public decimal? TotalAmount { get; set; }

        public string? Currency { get; set; }

        public string? Region { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public string? Note { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
