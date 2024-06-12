using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.ProductPage
{
    public class ProductModel : PageModel
    {
        private readonly IProductBusiness _productBusiness;
        public ProductModel(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            var result = await _productBusiness.GetAllProducts();
            Products = result.Data != null ? (List<Product>)result.Data : new List<Product>();

        }

        public void OnPost()
        {

        }
    }
}
