using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.DataAccess.Models;

namespace DiamondShopSystem.Business.Business.Interfaces
{
    public interface ICustomerBusiness
    {
        Task<IBusinessResult> GetAllCustomerAsync();
        Task<IBusinessResult> GetCustomerByIdAsync(int customerId);
        Task<IBusinessResult> CreateCustomerAsync(Customer customer);
        Task<IBusinessResult> UpdateCustomerAsync(Customer customer);
        Task<IBusinessResult> DeleteCustomerAsync(Customer customer);
        Task<IBusinessResult> DeleteCustomerAsync(int id);
    }
}
