using DiamondShopSystem.Data.Models;

namespace DiamondShopSystem.Business.Implement
{
    public interface IProductBusiness
    {
        Task<List<Product>> GetAllProducts();
    }
}
