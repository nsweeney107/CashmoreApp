using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CashmoreApp.Data;
using CashmoreApp.Models;

namespace CashmoreApp.Pages.Entities
{
    public class DetailsModel : PageModel
    {
        private readonly CashmoreApp.Data.CashmoreAppContext _context;

        public DetailsModel(CashmoreApp.Data.CashmoreAppContext context)
        {
            _context = context;
        }

        public Entity Entity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entity = await _context.Entities
                                .Include(e => e.EntityUsers)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(m => m.EntityID == id);

            if (Entity == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
