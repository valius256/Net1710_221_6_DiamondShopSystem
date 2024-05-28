using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.ProductPage
{
    public class ProductModel : PageModel
    {
        private readonly ProductBusiness _productBusiness;
        public ProductModel(ProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            var result = await _productBusiness.GetAllProducts();
            if (result != null)
            {
                Products = result.Data != null ? (List<Product>)result.Data : new List<Product>();
            }
        }

        public void OnPost()
        {

        }
    }
}
