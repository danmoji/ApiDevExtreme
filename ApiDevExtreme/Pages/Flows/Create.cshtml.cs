using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApiDevExtreme.Data;
using ApiDevExtreme.Models;

namespace ApiDevExtreme.Pages.Flows
{
    public class CreateModel : PageModel
    {
        private readonly ApiDevExtreme.Data.DashboardContext _context;

        public CreateModel(ApiDevExtreme.Data.DashboardContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Flow Flow { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Flows == null || Flow == null)
            {
                return Page();
            }

            _context.Flows.Add(Flow);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
