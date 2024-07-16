using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.Common.Dtos;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderDetailPage
{
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailBusiness _orderDetailBusiness;

        public IndexModel(IOrderDetailBusiness orderDetailBusiness)
        {
            _orderDetailBusiness = orderDetailBusiness;
        }

        public int PageNumber { get; set; }
        public int TotalPage { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public QueryOrderDetailDto QueryOrderDetailDto { get; set; } = default!;

        public async Task OnGetAsync(PageRequest pageRequest)
        {
            var queryOrderDetailDto = JsonConvert.DeserializeObject<QueryOrderDetailDto>(pageRequest.queryString) ?? new QueryOrderDetailDto();
            var dataResult = await _orderDetailBusiness.GetAllOrderDetailQuery(pageRequest.pageNumber, pageRequest.pageSize, queryOrderDetailDto);
            var result = dataResult.Data as PaginatedResult<OrderDetail>;
            TempData["PageNumber"] = PageNumber = pageRequest.pageNumber;
            TempData["PageSize"] = pageRequest.pageSize;
            TempData["TotalPage"] = TotalPage = result?.TotalPages ?? 1;
            TempData["QueryString"] = pageRequest.queryString;
            this.QueryOrderDetailDto = queryOrderDetailDto;

            OrderDetails = result?.Results ?? new List<OrderDetail>();
        }

        public IActionResult OnPostFilter()
        {
            int pageNumber = (int)(TempData["PageNumber"] ?? 1);
            int pageSize = (int)(TempData["PageSize"] ?? 1);
            int totalPage = (int)(TempData["TotalPage"] ?? 1);
            string queryJson = JsonConvert.SerializeObject(QueryOrderDetailDto);
            return RedirectToAction("Index", new PageRequest()
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
            return RedirectToAction("Index", new PageRequest()
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
            return RedirectToAction("Index", new PageRequest()
            {
                pageNumber = pageNumber,
                pageSize = pageSize,
                totalPage = totalPage,
                queryString = queryJson
            });
        }

    }
}
