using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PROIECT_SESIUNE_VINURI.Data;
using PROIECT_SESIUNE_VINURI.Pages.Models;

namespace PROIECT_SESIUNE_VINURI.Pages.Vinuri
{
    public class CreateModel : DistribuitorVinuriModel
    {
        private readonly PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext _context;

        public CreateModel(PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TaraID"] = new SelectList(_context.Set<Tara>(), "ID", "Nume");
            var vin = new Vin();
            vin.DistribuitoriDeVinuri = new List<DistribuitorVinuri>();
            IncarcaDistribuitorVinuriDat(_context, vin);
            return Page();
        }

        [BindProperty]
        public Vin Vin { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedDistribuitori)
        {
            var newVin = new Vin();
            if(selectedDistribuitori != null)
            {
                newVin.DistribuitoriDeVinuri = new List<DistribuitorVinuri>();
                    foreach ( var distri in selectedDistribuitori)
                {
                    var distriToAdd = new DistribuitorVinuri
                    {
                        DistribuitorID = int.Parse(distri)
                    };
                    newVin.DistribuitoriDeVinuri.Add(
                        distriToAdd);
                }
            }
           
            if (await TryUpdateModelAsync<Vin>(newVin, "Vi", i => i.Nume, i => i.An, i => i.Tip,
                i => i.Culoare, i => i.Pret, i => i.TaraID))
            {
                _context.Vin.Add(newVin);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");

            }

            IncarcaDistribuitorVinuriDat(_context, newVin);
            return Page();
        }

    }
    
}
