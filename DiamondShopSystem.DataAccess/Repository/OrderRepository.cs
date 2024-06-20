using DiamondShopSystem.Data.Models;
using DiamondShopSystem.DataAccess.Base;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.DataAccess.Repository
{
    public class OrderRepository : GenericRepository<Order>
    {
        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(ld => ld.Customer).ToListAsync();
        }

    }
}
