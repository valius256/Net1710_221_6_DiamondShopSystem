namespace DiamondShopSystem.Business.ViewModels
{
    public interface IOrderResult
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }

        public string DeliveryStatus { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }

    public class OrderResult : IOrderResult
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }

        public string DeliveryStatus { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public OrderResult()
        {

        }
    }
}
