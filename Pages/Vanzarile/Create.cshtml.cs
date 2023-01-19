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





//SELECT [d].[ID], [d].[Nume_Firma]
//FROM[Distribuitor] AS[d]



namespace PROIECT_SESIUNE_VINURI.Pages.Vanzarile
{
    public class CreateModel : PageModel
    {
        private readonly PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext _context;

        public CreateModel(PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var vinList = _context.Vin.Include(b => b.Tara).Select(x => new
            {
                x.ID,
                full = x.Nume + "-" + x.Tara.Nume
            });
        ViewData["UserID"] = new SelectList(_context.User, "ID", "NumeIntreg");
        ViewData["VinID"] = new SelectList(vinList, "ID", "full");
            return Page();
        }

        [BindProperty]
        public Vanzari Vanzari { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vanzari.Add(Vanzari);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
