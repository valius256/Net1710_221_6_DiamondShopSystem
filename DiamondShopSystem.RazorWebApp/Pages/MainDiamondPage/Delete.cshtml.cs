using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiamondShopSystem.DataAccess.Models;
using DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext;

namespace DiamondShopSystem.RazorWebApp.Pages.MainDiamondPage
{
    public class DeleteModel : PageModel
    {
        private readonly DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext.cs _context;

        public DeleteModel(DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext.cs context)
        {
            _context = context;
        }

        [BindProperty]
        public MainDiamond MainDiamond { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maindiamond = await _context.MainDiamond.FirstOrDefaultAsync(m => m.MainDiamondId == id);

            if (maindiamond == null)
            {
                return NotFound();
            }
            else
            {
                MainDiamond = maindiamond;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maindiamond = await _context.MainDiamond.FindAsync(id);
            if (maindiamond != null)
            {
                MainDiamond = maindiamond;
                _context.MainDiamond.Remove(MainDiamond);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
