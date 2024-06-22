using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiamondShopSystem.DataAccess.Models;
using DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext;

namespace DiamondShopSystem.RazorWebApp.Pages.DiamondSettingPage
{
    public class DeleteModel : PageModel
    {
        private readonly DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext.cs _context;

        public DeleteModel(DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext.cs context)
        {
            _context = context;
        }

        [BindProperty]
        public DiamondSetting DiamondSetting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diamondsetting = await _context.DiamondSetting.FirstOrDefaultAsync(m => m.DiamondSettingId == id);

            if (diamondsetting == null)
            {
                return NotFound();
            }
            else
            {
                DiamondSetting = diamondsetting;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diamondsetting = await _context.DiamondSetting.FindAsync(id);
            if (diamondsetting != null)
            {
                DiamondSetting = diamondsetting;
                _context.DiamondSetting.Remove(DiamondSetting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
