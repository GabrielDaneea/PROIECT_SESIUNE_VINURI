using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROIECT_SESIUNE_VINURI.Data;
using PROIECT_SESIUNE_VINURI.Pages.Models;

namespace PROIECT_SESIUNE_VINURI.Pages.Vinuri
{
    public class EditModel : PageModel
    {
        private readonly PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext _context;

        public EditModel(PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vin Vin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vin == null)
            {
                return NotFound();
            }

            var vin =  await _context.Vin.FirstOrDefaultAsync(m => m.ID == id);
            if (vin == null)
            {
                return NotFound();
            }
            ViewData["TaraID"] = new SelectList(_context.Set<Tara>(), "ID",
"Nume");
            Vin = vin;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinExists(Vin.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VinExists(int id)
        {
          return _context.Vin.Any(e => e.ID == id);
        }
    }
}
