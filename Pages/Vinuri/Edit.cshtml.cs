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
    public class EditModel : DistribuitorVinuriModel
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

            var vin = await _context.Vin.Include(b => b.Tara).Include(b => b.DistribuitoriDeVinuri).ThenInclude(b => b.Distribuitor).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (vin == null)
            {
                return NotFound();
            }
            IncarcaDistribuitorVinuriDat(_context, vin);

            ViewData["TaraID"] = new SelectList(_context.Set<Tara>(), "ID", "Nume");
            Vin = vin;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedDistribuitori)
        {
            if (id == null)
            {
                return null;

            }
            var vinToUpdate = await _context.Vin.Include(i => i.Tara).Include(i => i.DistribuitoriDeVinuri).ThenInclude(i => i.Distribuitor).FirstOrDefaultAsync(s => s.ID == id);
            if (vinToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Vin>(vinToUpdate, "Vin", i => i.Nume, i => i.An, i => i.Tip, i => i.Culoare, i => i.Pret, i => i.Tara))
            {
                UpdateDistribuitorVinuri(_context, selectedDistribuitori, vinToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateDistribuitorVinuri(_context, selectedDistribuitori, vinToUpdate);
            IncarcaDistribuitorVinuriDat(_context, vinToUpdate);
            return Page();
        }
    }
}
