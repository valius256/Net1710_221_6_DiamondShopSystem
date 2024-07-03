namespace DiamondShopSystem.Common.Dtos
{
    public class PageRequest
    {
        public int pageNumber { get; set; } = 1;

        public int pageSize { get; set; } = 5;

        public int totalPage { get; set; } = 1;
        public string queryString { get; set; } = string.Empty;
    }
}
