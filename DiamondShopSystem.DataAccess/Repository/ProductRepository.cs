using DiamondShopSystem.Common.Dtos;
using DiamondShopSystem.DataAccess.Base;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        public async Task<Product?> GetDetailProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.MainDiamond)
                .Include(p => p.SideStone)
                .Include(p => p.DiamondSetting)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }
        public async Task<PaginatedResult<Product>> GetQueriedProducts(int pageNumber, int pageSize, QueryProductDto queryProductDto)
        {
            var query =  _context.Products
                .Include(p => p.MainDiamond)
                .Include(p => p.SideStone)
                .Include(p => p.DiamondSetting)
                .AsQueryable();

            if (queryProductDto.ProductName != null)
            {
                 query = query.Where(p => p.ProductName.Contains(queryProductDto.ProductName));
            }
            if (queryProductDto.Status != null)
            {
                query = query.Where(p => p.Status == queryProductDto.Status);
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
                query = query.Where(p => p.Description != null && p.Description.Contains(queryProductDto.Description));
            }

            var paginatedResult = await query
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            // Count the total number of records
            int totalRecords = await query.CountAsync();

            // Calculate the total number of pages
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var result = new PaginatedResult<Product>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords,
                Results = paginatedResult
            };

            return result;
        }

    }
}
