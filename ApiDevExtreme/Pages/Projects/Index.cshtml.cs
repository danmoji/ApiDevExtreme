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
    public class IndexModel : PageModel
    {
        private readonly ApiDevExtreme.Data.DashboardContext _context;

        public IndexModel(ApiDevExtreme.Data.DashboardContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Projects != null)
            {
                Project = await _context.Projects.ToListAsync();
            }
        }
    }
}
