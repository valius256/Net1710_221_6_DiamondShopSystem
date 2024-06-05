using DiamondShopSystem.Data.Models;
using DiamondShopSystem.DataAccess.Base;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.DataAccess.Repository
{
    public class ProductRepository : GenericRepository<Product>
    {
        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products
                .Include(p => p.MainDiamond)
                .Include(p => p.SideStone)
                .Include(p => p.DiamondSetting)
                .ToListAsync();
        }
    }
}
