using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.Common.Dtos;
using DiamondShopSystem.DataAccess.Models;

namespace DiamondShopSystem.Business.Business.Interfaces
{
    public interface IProductBusiness
    {
        Task<IBusinessResult> GetAllProducts();
        Task<IBusinessResult> GetProductQueried(QueryProductDto queryProductDto);
        Task<IBusinessResult> GetByIdAsync(int id);
        Task<IBusinessResult> CreateProduct(Product product);
        Task<IBusinessResult> UpdateProduct(Product product);
        Task<IBusinessResult> DeleteProduct(int id);
    }
}
