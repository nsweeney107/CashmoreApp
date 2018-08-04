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
    public class DeleteModel : PageModel
    {
        private readonly CashmoreApp.Data.CashmoreAppContext _context;

        public DeleteModel(CashmoreApp.Data.CashmoreAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entity Entity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entity = await _context.Entities.FirstOrDefaultAsync(m => m.EntityID == id);

            if (Entity == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entity = await _context.Entities.FindAsync(id);

            if (Entity != null)
            {
                _context.Entities.Remove(Entity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
