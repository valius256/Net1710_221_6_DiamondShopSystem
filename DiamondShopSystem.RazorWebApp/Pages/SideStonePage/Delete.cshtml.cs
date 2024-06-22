using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiamondShopSystem.DataAccess.Models;
using DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext;

namespace DiamondShopSystem.RazorWebApp.Pages.SideStonePage
{
    public class DeleteModel : PageModel
    {
        private readonly DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext.cs _context;

        public DeleteModel(DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext.cs context)
        {
            _context = context;
        }

        [BindProperty]
        public SideStone SideStone { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sidestone = await _context.SideStone.FirstOrDefaultAsync(m => m.SideStoneId == id);

            if (sidestone == null)
            {
                return NotFound();
            }
            else
            {
                SideStone = sidestone;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sidestone = await _context.SideStone.FindAsync(id);
            if (sidestone != null)
            {
                SideStone = sidestone;
                _context.SideStone.Remove(SideStone);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
