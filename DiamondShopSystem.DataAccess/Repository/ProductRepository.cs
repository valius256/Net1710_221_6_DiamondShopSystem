using DiamondShopSystem.Common.Dtos;
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

        public async Task<List<Product>> GetQueriedProducts(QueryProductDto queryProductDto)
        {
            var query =  _context.Products
                .AsQueryable();

            if (queryProductDto.ProductName != null)
            {
                 query = query.Where(p => p.ProductName.Contains(queryProductDto.ProductName));
            }
            if (queryProductDto.Status != null)
            {
                query = query.Where(p => p.Status != queryProductDto.Status);
            }
            if (queryProductDto.UpperPrice.HasValue)
            {
                query = query.Where(p => p.Price <= queryProductDto.UpperPrice);
            }
            if (queryProductDto.LowerPrice.HasValue)
            {
                query = query.Where(p => p.Price >= queryProductDto.LowerPrice);
            }
            if (queryProductDto.Description != null)
            {
                query = query.Where(p => p.Description.Contains(queryProductDto.Description));
            }

            return await query
                 .Include(p => p.MainDiamond)
                 .Include(p => p.SideStone)
                 .Include(p => p.DiamondSetting)
                .ToListAsync();
        }

    }
}
