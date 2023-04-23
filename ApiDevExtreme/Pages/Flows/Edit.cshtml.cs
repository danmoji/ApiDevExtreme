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

namespace ApiDevExtreme.Pages.Flows
{
    public class EditModel : PageModel
    {
        private readonly ApiDevExtreme.Data.DashboardContext _context;

        public EditModel(ApiDevExtreme.Data.DashboardContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Flow Flow { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Flows == null)
            {
                return NotFound();
            }

            var flow =  await _context.Flows.FirstOrDefaultAsync(m => m.Id == id);
            if (flow == null)
            {
                return NotFound();
            }
            Flow = flow;
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

            _context.Attach(Flow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlowExists(Flow.Id))
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

        private bool FlowExists(int id)
        {
          return (_context.Flows?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
