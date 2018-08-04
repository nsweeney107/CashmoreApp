using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CashmoreApp.Data;
using CashmoreApp.Models;

namespace CashmoreApp.Pages.Contracts
{
    public class CreateModel : PageModel
    {
        private readonly CashmoreApp.Data.CashmoreAppContext _context;

        public CreateModel(CashmoreApp.Data.CashmoreAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Contract Contract { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contracts.Add(Contract);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}