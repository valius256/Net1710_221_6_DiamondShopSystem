namespace DiamondShopSystem.Business.Dtos
{
    public class QueryMainDiamondDto
    {
        public int? MainDiamondType { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public string? Description { get; set; }

        public decimal LowerPrice { get; set; }
        public decimal UpperPrice { get; set; }

        public string Certificate { get; set; } = string.Empty;

        public int? Origin { get; set; }

        public int? Size { get; set; }

        public decimal? LowerCaratWeight { get; set; }
        public decimal? UpperCaratWeight { get; set; }

        public decimal? CaratWeight { get; set; }

        public int? Color { get; set; }

        public int? Clarity { get; set; }

        public int? Cut { get; set; }

        public string? Name { get; set; }
    }
}
