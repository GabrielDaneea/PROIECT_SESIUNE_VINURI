using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PROIECT_SESIUNE_VINURI.Data;
using PROIECT_SESIUNE_VINURI.Pages.Models;

namespace PROIECT_SESIUNE_VINURI.Pages.Vanzarile
{
    public class DeleteModel : PageModel
    {
        private readonly PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext _context;

        public DeleteModel(PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Vanzari Vanzari { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vanzari == null)
            {
                return NotFound();
            }

            var vanzari = await _context.Vanzari.FirstOrDefaultAsync(m => m.ID == id);

            if (vanzari == null)
            {
                return NotFound();
            }
            else 
            {
                Vanzari = vanzari;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Vanzari == null)
            {
                return NotFound();
            }
            var vanzari = await _context.Vanzari.FindAsync(id);

            if (vanzari != null)
            {
                Vanzari = vanzari;
                _context.Vanzari.Remove(Vanzari);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
