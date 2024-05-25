namespace DiamondShopSystem.Data.Models
{
    public interface ICustomerResult
    {
        public int CustomerId { get; set; }

        public string Email { get; set; }

        public int Gender { get; set; }

        public string Birthday { get; set; }

        public string Address { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }

    public class CustomerResult : ICustomerResult
    {
        public int CustomerId { get; set; }

        public string Email { get; set; }

        public int Gender { get; set; }

        public string Birthday { get; set; }

        public string Address { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}
