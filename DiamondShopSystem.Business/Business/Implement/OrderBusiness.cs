using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.Business.Business.Imp
{


    public class OrderBusiness : IOrderBusiness
    {
        private readonly Net1710_221_6_DiamondShopSystemContext _context;

        public async Task<List<Order>> GetAllOrder()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> getOrderByIdTask(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task<Order> CreateOrderTask(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderTask(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> DeleteOrderTask(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
