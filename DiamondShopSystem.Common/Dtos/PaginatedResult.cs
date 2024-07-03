
namespace DiamondShopSystem.Common.Dtos
{
    public class PaginatedResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public List<T> Results { get; set; } = new List<T>();
    }
}
