using System;

namespace DiamondShopSystem.Business.Dtos
{
    public class QueryOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal? Fee { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public decimal? Discount { get; set; }
        public string OrderDetailNote { get; set; } = string.Empty;
    }
}
