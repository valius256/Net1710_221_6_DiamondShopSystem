using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.DataAccess.Models;

namespace DiamondShopSystem.Business.Business.Interfaces
{
    public interface IOrderBusiness
    {
        Task<IBusinessResult> GetAllOrder();
        Task<IBusinessResult> GetOrderById(int id);
        Task<IBusinessResult> CreateOrder(Order order);
        Task<IBusinessResult> UpdateOrder(Order order);
        Task<IBusinessResult> DeleteOrder(int id);
        Task<IBusinessResult> Save(Order order);
    }
}
