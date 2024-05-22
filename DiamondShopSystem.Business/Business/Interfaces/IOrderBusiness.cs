using DiamondShopSystem.Data.Models;

namespace DiamondShopSystem.Business.Business.Interfaces
{
    public interface IOrderBusiness
    {

        Task<List<Order>?> GetAllOrderAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<bool> CreateOrderAsync(Order order);
        Task<bool> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int id);
    }
}
