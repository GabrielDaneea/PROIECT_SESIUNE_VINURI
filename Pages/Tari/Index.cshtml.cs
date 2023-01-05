using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PROIECT_SESIUNE_VINURI.Data;
using PROIECT_SESIUNE_VINURI.Pages.Models;

namespace PROIECT_SESIUNE_VINURI.Pages.Tari
{
    public class IndexModel : PageModel
    {
        private readonly PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext _context;

        public IndexModel(PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext context)
        {
            _context = context;
        }

        public IList<Tara> Tara { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tara != null)
            {
                Tara = await _context.Tara.ToListAsync();
            }
        }
    }
}
