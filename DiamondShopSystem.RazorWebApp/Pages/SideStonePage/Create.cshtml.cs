﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DiamondShopSystem.DataAccess.Models;
using DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext;

namespace DiamondShopSystem.RazorWebApp.Pages.SideStonePage
{
    public class CreateModel : PageModel
    {
        private readonly DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext.cs _context;

        public CreateModel(DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext.cs context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SideStone SideStone { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SideStone.Add(SideStone);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
