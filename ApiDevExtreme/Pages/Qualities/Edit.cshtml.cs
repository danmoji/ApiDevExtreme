using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiDevExtreme.Data;
using ApiDevExtreme.Models;

namespace ApiDevExtreme.Pages.Qualities
{
    public class EditModel : PageModel
    {
        private readonly ApiDevExtreme.Data.DashboardContext _context;

        public EditModel(ApiDevExtreme.Data.DashboardContext context)
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

            var quality =  await _context.Qualities.FirstOrDefaultAsync(m => m.Id == id);
            if (quality == null)
            {
                return NotFound();
            }
            Quality = quality;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Quality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QualityExists(Quality.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QualityExists(int id)
        {
          return (_context.Qualities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
