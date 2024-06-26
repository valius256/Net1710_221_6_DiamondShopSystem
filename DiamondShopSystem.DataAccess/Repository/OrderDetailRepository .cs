using DiamondShopSystem.DataAccess.Models;
using DiamondShopSystem.DataAccess.Base;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.DataAccess.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>
    {

        public OrderDetailRepository() { }

        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await _context.OrderDetails.Include(ld => ld.Order).Include(ld => ld.Product).ToListAsync();
        }

        public async Task<OrderDetail> GetByIdAsync(int? id)
        {
            return await _context.OrderDetails.Include(ld => ld.Order).Include(ld => ld.Product).FirstOrDefaultAsync(ld => ld.ProductId == id);
        }


    }
}
