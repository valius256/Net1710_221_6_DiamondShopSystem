using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.CustomerPage
{
    public class CustomerModel : PageModel
    {
        private readonly ICustomerBusiness _customerBusiness;
        public CustomerModel(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }
        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();

        public async Task OnGetAsync()
        {
            var result = await _customerBusiness.GetAllCustomerAsync();
            Customers = result.Data != null ? (List<Customer>)result.Data : new List<Customer>();

        }

        public void OnPost()
        {

        }
    }
}
