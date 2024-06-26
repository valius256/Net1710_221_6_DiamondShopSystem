using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.DataAccess.Models;
using DiamondShopSystem.DataAccess.Models;

namespace DiamondShopSystem.Business.Business.Interfaces
{
    public interface IOrderDetailBusiness
    {

        Task<IBusinessResult> GetAllOrderDetail();
        Task<IBusinessResult> GetOrderDetailById(int? id);
        Task<IBusinessResult> CreateOrderDetail(OrderDetail order);
        Task<IBusinessResult> UpdateOrderDetail(OrderDetail order);
        Task<IBusinessResult> DeleteOrderDetail(int id);
    }
}
