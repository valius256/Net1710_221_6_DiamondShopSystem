using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.Product
{
    public class ProductModel : PageModel
    {
        private readonly ProductBusiness _productBusiness;
        public ProductModel(ProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }
        public IEnumerable<Data.Models.Product> Products { get; set; } = new List<Data.Models.Product>();

        public async void OnGet()
        {
            var result = await _productBusiness.GetAllProducts();
            if (result != null)
            {
                Products = result.Data != null ? (List<Data.Models.Product>)result.Data : new List<Data.Models.Product>();
            }
        }
    }
}
