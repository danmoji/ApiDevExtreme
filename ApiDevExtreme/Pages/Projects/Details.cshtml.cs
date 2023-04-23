using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApiDevExtreme.Data;
using ApiDevExtreme.Models;

namespace ApiDevExtreme.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly ApiDevExtreme.Data.DashboardContext _context;

        public DetailsModel(ApiDevExtreme.Data.DashboardContext context)
        {
            _context = context;
        }

      public Project Project { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            else 
            {
                Project = project;
            }
            return Page();
        }
    }
}
