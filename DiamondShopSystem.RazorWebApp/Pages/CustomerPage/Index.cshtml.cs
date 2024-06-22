using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.CustomerPage
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerBusiness _customerBusiness;
        public IndexModel(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        public IList<Customer> Customer { get; set; } = default!;

        public QueryCustomerDto queryCustomerDto { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = (await _customerBusiness.GetAllCustomerAsync()).Data as List<Customer> ?? new List<Customer>();
        }
    }
}
