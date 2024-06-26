namespace DiamondShopSystem.Business.Dtos
{
    public class QueryCustomerDto
    {
        public string Email { get; set; } = string.Empty;

        public int? Gender { get; set; }

        public string? Birthday { get; set; }

        public string? Address { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? CompanyName { get; set; }
    }
}
