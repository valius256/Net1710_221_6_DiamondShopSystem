using DiamondShopSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.Business.Implement
{

    public class ProductBusiness : IProductBusiness
    {
        private readonly Net1710_221_6_DiamondShopSystemContext _context;

        public ProductBusiness(Net1710_221_6_DiamondShopSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
