using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderPage
{
    public class IndexModel : PageModel
    {
        private readonly IOrderBusiness _orderBusiness;

        public IndexModel(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }


        [BindProperty(SupportsGet = true)]
        public QueryOrderDto QueryOrderDto { get; set; } = default!;

        public IList<Order> Order { get; set; } = new List<Order>();//default!;

        public async Task OnGetAsync()
        {
            Order = (await _orderBusiness.GetQueriedOrder(QueryOrderDto)).Data as List<Order> ?? new List<Order>();
        }

        public void OnPost()
        {
            RedirectToAction("Index", QueryOrderDto);
        }

    }
}
