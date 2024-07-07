using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Common.Dtos;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DiamondShopSystem.RazorWebApp.Pages.ProductPage
{
    public class IndexModel : PageModel
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IMainDiamondBusiness _mainDiamondBusiness;
        private readonly IDiamondSettingBusiness _diamondSettingBusiness;
        private readonly ISideStoneBusiness _sideStoneBusiness;
        public IndexModel(IProductBusiness productBusiness, IMainDiamondBusiness mainDiamondBusiness, IDiamondSettingBusiness diamondSettingBusiness, ISideStoneBusiness sideStoneBusiness)
        {
            _productBusiness = productBusiness;
            _mainDiamondBusiness = mainDiamondBusiness;
            _diamondSettingBusiness = diamondSettingBusiness;
            _sideStoneBusiness = sideStoneBusiness;
        }
        public IList<Product> Product { get; set; } = new List<Product>();
        public IList<SideStone> SideStones { get; set; } = default!;
        public IList<DiamondSetting> DiamondSettings { get; set; } = default!;
        public IList<MainDiamond> MainDiamonds { get; set; } = default!;
        [BindProperty]
        public QueryProductDto queryProductDto { get; set; } = new QueryProductDto();
        public int PageNumber { get; set; }
        public int TotalPage { get; set; }

        public async Task OnGetAsync(PageRequest pageRequest)
        {
            var queryProductDto = JsonConvert.DeserializeObject<QueryProductDto>(pageRequest.queryString) ?? new QueryProductDto();
            var dataResult = await _productBusiness.GetProductQueried(pageRequest.pageNumber, pageRequest.pageSize, queryProductDto);
            var result = dataResult.Data as PaginatedResult<Product>;
            TempData["PageNumber"] = PageNumber = pageRequest.pageNumber;
            TempData["PageSize"] = pageRequest.pageSize;
            TempData["TotalPage"] = TotalPage = result?.TotalPages ?? 1;
            TempData["QueryString"] = pageRequest.queryString;
            this.queryProductDto = queryProductDto;

            Product = result?.Results ?? new List<Product>();
        }
        public IActionResult OnPostFilter()
        {
            //TempData["Query"] = JsonConvert.SerializeObject(queryProductDto);
            // Redirect to GET action (OnGet method)
            int pageNumber = (int)(TempData["PageNumber"] ?? 1);
            int pageSize = (int)(TempData["PageSize"] ?? 1);
            int totalPage = (int)(TempData["TotalPage"] ?? 1);
            string queryJson = JsonConvert.SerializeObject(queryProductDto);
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
            //TempData["Query"] = JsonConvert.SerializeObject(queryProductDto) ;

            // Redirect to GET action (OnGet method)
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
            //TempData["Query"] = JsonConvert.SerializeObject(queryProductDto);
            // Redirect to GET action (OnGet method)
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
