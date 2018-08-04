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
    public class IndexModel : PageModel
    {
        private readonly CashmoreApp.Data.CashmoreAppContext _context;

        public IndexModel(CashmoreApp.Data.CashmoreAppContext context)
        {
            _context = context;
        }

        public IList<Contract> Contract { get;set; }

        public async Task OnGetAsync()
        {
            Contract = await _context.Contracts.ToListAsync();
        }
    }
}
