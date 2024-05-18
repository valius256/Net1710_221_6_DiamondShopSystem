using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiamondShopSystem.Data.Models;

namespace DiamondShopSystem.Business.Business.Interfaces
{
    public interface IOrderBusiness
    {

        Task<List<Order>> GetAllOrder();
        Task<Order> getOrderByIdTask(int id);
    }
}
