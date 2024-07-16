using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.Common.Dtos;
using DiamondShopSystem.DataAccess.Base;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.DataAccess.Repository
{
    public class OrderRepository : GenericRepository<Order>
    {
        public async Task<List<Order>> GetAllOrderAsync()
        {
            return await _context.Orders.Include(ld => ld.Customer).ToListAsync();
        }

        public async Task<PaginatedResult<Order>> GetQueriedOrder(int pageNumber, int pageSize, QueryOrderDto queryOrderDto)
        {
            var query = _context.Orders.AsQueryable();

            if (queryOrderDto != null)
            {
                if (queryOrderDto.OrderId.HasValue)
                {
                    query = query.Where(o => o.OrderId == queryOrderDto.OrderId.Value);
                }

                if (!string.IsNullOrEmpty(queryOrderDto.OrderStatus))
                {
                    query = query.Where(o => o.OrderStatus.Contains(queryOrderDto.OrderStatus));
                }

                if (!string.IsNullOrEmpty(queryOrderDto.DeliveryStatus))
                {
                    query = query.Where(o => o.DeliveryStatus.Contains(queryOrderDto.DeliveryStatus));
                }

                if (queryOrderDto.TotalAmount.HasValue)
                {
                    query = query.Where(o => o.TotalAmount == queryOrderDto.TotalAmount.Value);
                }

                // Filter by OrderDate range
                if (queryOrderDto.OrderDateFrom.HasValue && queryOrderDto.OrderDateTo.HasValue)
                {
                    query = query.Where(o => o.OrderDate >= queryOrderDto.OrderDateFrom.Value && o.OrderDate <= queryOrderDto.OrderDateTo.Value);
                }
                else if (queryOrderDto.OrderDateFrom.HasValue)
                {
                    query = query.Where(o => o.OrderDate >= queryOrderDto.OrderDateFrom.Value);
                }
                else if (queryOrderDto.OrderDateTo.HasValue)
                {
                    query = query.Where(o => o.OrderDate <= queryOrderDto.OrderDateTo.Value);
                }

                if (queryOrderDto.CustomerId.HasValue)
                {
                    query = query.Where(o => o.CustomerId == queryOrderDto.CustomerId.Value);
                }
            }

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
            var paginatedResult = await query.Skip((pageNumber - 1) * pageSize)
                                             .Take(pageSize)
                                             .ToListAsync();

            var result = new PaginatedResult<Order>
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
