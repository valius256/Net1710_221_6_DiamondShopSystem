using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.Common.Dtos;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderPage
{
    public class IndexModel : PageModel
    {
        private readonly IOrderBusiness _orderBusiness;

        public IndexModel(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }

        public int PageNumber { get; set; }
        public int TotalPage { get; set; }
        public IList<Order> Orders { get; set; } = new List<Order>();

        [BindProperty(SupportsGet = true)]
        public QueryOrderDto QueryOrderDto { get; set; } = new QueryOrderDto();

        public async Task OnGetAsync(PageRequest pageRequest)
        {
            var queryOrderDto = JsonConvert.DeserializeObject<QueryOrderDto>(pageRequest.queryString) ?? new QueryOrderDto();
            var dataResult = await _orderBusiness.GetQueriedOrder(pageRequest.pageNumber, pageRequest.pageSize, queryOrderDto);
            var result = dataResult.Data as PaginatedResult<Order>;

            TempData["PageNumber"] = PageNumber = pageRequest.pageNumber;
            TempData["PageSize"] = pageRequest.pageSize;
            TempData["TotalPage"] = TotalPage = result?.TotalPages ?? 1;
            TempData["QueryString"] = pageRequest.queryString;
            QueryOrderDto = queryOrderDto;

            Orders = result?.Results ?? new List<Order>();
        }

        public IActionResult OnPostFilter()
        {
            int pageNumber = (int)(TempData["PageNumber"] ?? 1);
            int pageSize = (int)(TempData["PageSize"] ?? 1);
            int totalPage = (int)(TempData["TotalPage"] ?? 1);
            string queryJson = JsonConvert.SerializeObject(QueryOrderDto);
            return RedirectToPage("Index", new PageRequest()
            {
                pageNumber = pageNumber,
                pageSize = pageSize,
                totalPage = totalPage,
                queryString = queryJson
            });
        }

        public IActionResult OnPostPrevPage()
        {
            int pageNumber = (int)(TempData["PageNumber"] ?? 1);
            if (pageNumber > 1)
            {
                pageNumber--;
            }
            int pageSize = (int)(TempData["PageSize"] ?? 1);
            int totalPage = (int)(TempData["TotalPage"] ?? 1);
            string queryJson = (string)(TempData["QueryString"] ?? string.Empty);
            return RedirectToPage("Index", new PageRequest()
            {
                pageNumber = pageNumber,
                pageSize = pageSize,
                totalPage = totalPage,
                queryString = queryJson
            });
        }

        public IActionResult OnPostNextPage()
        {
            int pageNumber = (int)(TempData["PageNumber"] ?? 1);
            int totalPage = (int)(TempData["TotalPage"] ?? 1);
            if (pageNumber < totalPage)
            {
                pageNumber++;
            }
            int pageSize = (int)(TempData["PageSize"] ?? 1);
            string queryJson = (string)(TempData["QueryString"] ?? string.Empty);
            return RedirectToPage("Index", new PageRequest()
            {
                pageNumber = pageNumber,
                pageSize = pageSize,
                totalPage = totalPage,
                queryString = queryJson
            });
        }
    }
}
