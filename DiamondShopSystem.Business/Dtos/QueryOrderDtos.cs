namespace DiamondShopSystem.Business.Dtos;

public class QueryOrderDtos
{
    public int? OrderId { get; set; }
    public string? OrderStatus  { get; set; }
    public string? DeliveryStatus { get; set; } 
    public decimal? TotalAmount { get; set; }
    public string? Currency { get; set; }
    public string? Region { get; set; } 
}