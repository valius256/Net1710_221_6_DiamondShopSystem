using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.Common.Dtos;
using DiamondShopSystem.DataAccess.Base;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.DataAccess.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>
    {

        public OrderDetailRepository() { }

        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await _context.OrderDetails
                .Include(ld => ld.Order).Include(ld => ld.Product).ToListAsync();
        }

        public async Task<OrderDetail> GetByIdAsync(int? id)
        {
            return await _context.OrderDetails.Include(ld => ld.Order).Include(ld => ld.Product).FirstOrDefaultAsync(ld => ld.OrderDetailId == id);
        }

        public async Task<PaginatedResult<OrderDetail>> GetQueriedOrderDetails(int pageNumber, int pageSize, QueryOrderDetailDto queryOrderDetailDto)
        {
            var query = _context.OrderDetails.AsQueryable();

            if (queryOrderDetailDto.OrderDetailId.HasValue)
            {
                query = query.Where(od => od.OrderDetailId == queryOrderDetailDto.OrderDetailId.Value);
            }
            if (queryOrderDetailDto.OrderId.HasValue)
            {
                query = query.Where(od => od.OrderId == queryOrderDetailDto.OrderId.Value);
            }
            if (queryOrderDetailDto.ProductId.HasValue)
            {
                query = query.Where(od => od.ProductId == queryOrderDetailDto.ProductId.Value);
            }
            if (queryOrderDetailDto.Quantity.HasValue)
            {
                query = query.Where(od => od.Quantity == queryOrderDetailDto.Quantity.Value);
            }
            if (queryOrderDetailDto.Amount.HasValue)
            {
                query = query.Where(od => od.Amount == queryOrderDetailDto.Amount.Value);
            }
            if (queryOrderDetailDto.Fee.HasValue)
            {
                query = query.Where(od => od.Fee == queryOrderDetailDto.Fee.Value);
            }
            if (queryOrderDetailDto.CreateAt.HasValue)
            {
                query = query.Where(od => od.CreateAt.Value == queryOrderDetailDto.CreateAt.Value.Date);
            }
            if (queryOrderDetailDto.UpdateAt.HasValue)
            {
                query = query.Where(od => od.UpdateAt.Value == queryOrderDetailDto.UpdateAt.Value.Date);
            }
            if (queryOrderDetailDto.Discount.HasValue)
            {
                query = query.Where(od => od.Discount == queryOrderDetailDto.Discount.Value);
            }
            if (!string.IsNullOrEmpty(queryOrderDetailDto.OrderDetailNote))
            {
                query = query.Where(od => od.OrderDetailNote.Contains(queryOrderDetailDto.OrderDetailNote));
            }

            var paginatedResult = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Count the total number of records
            int totalRecords = await query.CountAsync();

            // Calculate the total number of pages
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var result = new PaginatedResult<OrderDetail>
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
