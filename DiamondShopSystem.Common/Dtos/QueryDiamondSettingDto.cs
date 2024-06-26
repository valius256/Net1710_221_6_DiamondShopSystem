namespace DiamondShopSystem.Business.Dtos
{
    public class QueryDiamondSettingDto
    {
        public string Name { get; set; } = string.Empty;

        public int? DiamondSettingCategory { get; set; }

        public string? Description { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public decimal LowerPrice { get; set; }
        public decimal UpperPrice { get; set; }

        public string? Image { get; set; }

        public string? DiamondSettingMaterial { get; set; }

        public decimal? LowerDiamondSettingWeight { get; set; }
        public decimal? UpperDiamondSettingWeight { get; set; }

        public string? DiamondSettingSize { get; set; }
    }
}
