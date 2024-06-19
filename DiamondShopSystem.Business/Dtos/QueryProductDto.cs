
namespace DiamondShopSystem.Business.Dtos
{
    public class QueryProductDto
    {

        public string ProductName { get; set; } = string.Empty;

        //public int DiamondSettingName { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal LowerPrice { get; set; }
        public decimal UpperPrice { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
