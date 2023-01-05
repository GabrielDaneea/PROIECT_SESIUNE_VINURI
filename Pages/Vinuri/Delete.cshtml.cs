using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PROIECT_SESIUNE_VINURI.Data;
using PROIECT_SESIUNE_VINURI.Pages.Models;

namespace PROIECT_SESIUNE_VINURI.Pages.Vinuri
{
    public class DeleteModel : PageModel
    {
        private readonly PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext _context;

        public DeleteModel(PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Vin Vin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vin == null)
            {
                return NotFound();
            }

            var vin = await _context.Vin.FirstOrDefaultAsync(m => m.ID == id);

            if (vin == null)
            {
                return NotFound();
            }
            else 
            {
                Vin = vin;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Vin == null)
            {
                return NotFound();
            }
            var vin = await _context.Vin.FindAsync(id);

            if (vin != null)
            {
                Vin = vin;
                _context.Vin.Remove(Vin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
