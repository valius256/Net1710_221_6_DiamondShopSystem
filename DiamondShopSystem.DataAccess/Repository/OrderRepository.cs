using DiamondShopSystem.Business.Dtos;
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

        public async Task<List<Order>> GetQueriedOrder(QueryOrderDto queryOrderDto)
        {
            var orders = _context.Orders.ToList();

            if (queryOrderDto != null)
            {
                if (queryOrderDto.OrderId.HasValue)
                {
                    orders = orders.Where(o => o.OrderId == queryOrderDto.OrderId.Value).ToList();
                }

                if (!string.IsNullOrEmpty(queryOrderDto.OrderStatus))
                {
                    orders = orders
                        .Where(o => o.OrderStatus.Contains(queryOrderDto.OrderStatus))
                        .ToList();
                }

                if (!string.IsNullOrEmpty(queryOrderDto.DeliveryStatus))
                {
                    orders = orders
                        .Where(o => o.DeliveryStatus.Contains(queryOrderDto.DeliveryStatus))
                        .ToList();
                }

                if (queryOrderDto.TotalAmount.HasValue)
                {
                    orders = orders
                        .Where(o => o.TotalAmount == queryOrderDto.TotalAmount.Value)
                        .ToList();
                }

                // Filter by OrderDate range
                if (queryOrderDto.OrderDateFrom.HasValue && queryOrderDto.OrderDateTo.HasValue)
                {
                    orders = orders
                        .Where(o => o.OrderDate >= queryOrderDto.OrderDateFrom.Value && o.OrderDate <= queryOrderDto.OrderDateTo.Value)
                        .ToList();
                }
                else if (queryOrderDto.OrderDateFrom.HasValue)
                {
                    orders = orders
                        .Where(o => o.OrderDate >= queryOrderDto.OrderDateFrom.Value)
                        .ToList();
                }
                else if (queryOrderDto.OrderDateTo.HasValue)
                {
                    orders = orders
                        .Where(o => o.OrderDate <= queryOrderDto.OrderDateTo.Value)
                        .ToList();
                }
                if (queryOrderDto.CustomerId.HasValue)
                {
                    orders = orders
                        .Where(o => o.OrderId == queryOrderDto.CustomerId.Value)
                        .ToList();
                }
            }


            return orders;
        }



    }
}
