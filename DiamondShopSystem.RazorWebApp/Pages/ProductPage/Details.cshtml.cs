﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiamondShopSystem.Data.Models;
using DiamondShopSystem.RazorWebApp.DataAccess;
using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;

namespace DiamondShopSystem.RazorWebApp.Pages.ProductPage
{
    public class DetailsModel : PageModel
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IMainDiamondBusiness _mainDiamondBusiness;
        private readonly IDiamondSettingBusiness _diamondSettingBusiness;
        private readonly ISideStoneBusiness _sideStoneBusiness;
        public DetailsModel(IProductBusiness productBusiness, IMainDiamondBusiness mainDiamondBusiness, IDiamondSettingBusiness diamondSettingBusiness, ISideStoneBusiness sideStoneBusiness)
        {
            _productBusiness = productBusiness;
            _mainDiamondBusiness = mainDiamondBusiness;
            _diamondSettingBusiness = diamondSettingBusiness;
            _sideStoneBusiness = sideStoneBusiness;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = (await _productBusiness.GetByIdAsync((int) id)).Data as Product;
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }
    }
}
