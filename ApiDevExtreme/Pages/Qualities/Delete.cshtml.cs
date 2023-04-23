using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApiDevExtreme.Data;
using ApiDevExtreme.Models;

namespace ApiDevExtreme.Pages.Qualities
{
    public class DeleteModel : PageModel
    {
        private readonly ApiDevExtreme.Data.DashboardContext _context;

        public DeleteModel(ApiDevExtreme.Data.DashboardContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Quality Quality { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Qualities == null)
            {
                return NotFound();
            }

            var quality = await _context.Qualities.FirstOrDefaultAsync(m => m.Id == id);

            if (quality == null)
            {
                return NotFound();
            }
            else 
            {
                Quality = quality;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Qualities == null)
            {
                return NotFound();
            }
            var quality = await _context.Qualities.FindAsync(id);

            if (quality != null)
            {
                Quality = quality;
                _context.Qualities.Remove(Quality);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
