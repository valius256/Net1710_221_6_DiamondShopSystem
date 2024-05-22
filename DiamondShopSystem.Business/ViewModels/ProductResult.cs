public interface IProductResult
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public int DiamondSettingId { get; set; }

    public string Description { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public decimal Price { get; set; }

    public string Warranty { get; set; }

    public string Status { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Terms { get; set; }

    public int SideStoneId { get; set; }

    public int SideStoneAmount { get; set; }

    public int MainDiamondId { get; set; }
}

public class ProductResult : IProductResult
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public int DiamondSettingId { get; set; }

    public string Description { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public decimal Price { get; set; }

    public string Warranty { get; set; }

    public string Status { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Terms { get; set; }

    public int SideStoneId { get; set; }

    public int SideStoneAmount { get; set; }

    public int MainDiamondId { get; set; }

    public ProductResult()
    {
       
    }
}