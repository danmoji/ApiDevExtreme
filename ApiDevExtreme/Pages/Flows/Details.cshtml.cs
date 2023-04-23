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
    public class DetailsModel : PageModel
    {
        private readonly ApiDevExtreme.Data.DashboardContext _context;

        public DetailsModel(ApiDevExtreme.Data.DashboardContext context)
        {
            _context = context;
        }

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
    }
}
