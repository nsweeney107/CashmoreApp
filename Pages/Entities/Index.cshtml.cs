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
    public class IndexModel : PageModel
    {
        private readonly CashmoreApp.Data.CashmoreAppContext _context;

        public IndexModel(CashmoreApp.Data.CashmoreAppContext context)
        {
            _context = context;
        }

        public IList<Entity> Entity { get;set; }

        public async Task OnGetAsync()
        {
            Entity = await _context.Entities.ToListAsync();
        }
    }
}
