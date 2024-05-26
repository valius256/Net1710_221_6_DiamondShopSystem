using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.Data.Models;

namespace DiamondShopSystem.Business.Business.Interfaces
{
    public interface IOrderBusiness
    {

        Task<IBusinessResult> GetAllOrderAsync();
        Task<IBusinessResult> GetOrderByIdAsync(int id);
        Task<IBusinessResult> CreateOrderAsync(Order order);
        Task<IBusinessResult> UpdateOrderAsync(Order order);
        Task<IBusinessResult> DeleteOrderAsync(Order order);
    }
}
