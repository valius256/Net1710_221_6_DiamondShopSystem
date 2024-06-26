namespace DiamondShopSystem.Business.Dtos
{
    public class QuerySideStoneDto
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal LowerPrice { get; set; }
        public decimal UpperPrice { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public decimal? LowerSideStoneWeight { get; set; }
        public decimal? UpperSideStoneWeight { get; set; }

        public string? SideStoneSize { get; set; }

        public string? SideStoneMaterial { get; set; }

        public string? SideStoneCategory { get; set; }

        // Adding the new property
        public decimal? SideStoneWeight { get; set; }
    }
}
