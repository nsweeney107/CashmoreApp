using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CashmoreApp.Data;
using CashmoreApp.Models;

namespace CashmoreApp.Pages.Contracts
{
    public class DeleteModel : PageModel
    {
        private readonly CashmoreApp.Data.CashmoreAppContext _context;

        public DeleteModel(CashmoreApp.Data.CashmoreAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contract Contract { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contract = await _context.Contracts.SingleOrDefaultAsync(m => m.ContractID == id);

            if (Contract == null)
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

            Contract = await _context.Contracts.FindAsync(id);

            if (Contract != null)
            {
                _context.Contracts.Remove(Contract);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
