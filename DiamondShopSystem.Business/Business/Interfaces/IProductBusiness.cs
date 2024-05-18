using DiamondShopSystem.Data.Models;

namespace DiamondShopSystem.Business.Business.Interfaces
{
    public interface IProductBusiness
    {
        Task<List<Product>> GetAllProducts();
    }
}
