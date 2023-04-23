using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApiDevExtreme.Data;
using ApiDevExtreme.Models;

namespace ApiDevExtreme.Pages.Flows
{
    public class DeleteModel : PageModel
    {
        private readonly ApiDevExtreme.Data.DashboardContext _context;

        public DeleteModel(ApiDevExtreme.Data.DashboardContext context)
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

            var flow = await _context.Flows.FirstOrDefaultAsync(m => m.Id == id);

            if (flow == null)
            {
                return NotFound();
            }
            else 
            {
                Flow = flow;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Flows == null)
            {
                return NotFound();
            }
            var flow = await _context.Flows.FindAsync(id);

            if (flow != null)
            {
                Flow = flow;
                _context.Flows.Remove(Flow);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
