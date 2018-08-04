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
    public class DetailsModel : PageModel
    {
        private readonly CashmoreApp.Data.CashmoreAppContext _context;

        public DetailsModel(CashmoreApp.Data.CashmoreAppContext context)
        {
            _context = context;
        }

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
    }
}
