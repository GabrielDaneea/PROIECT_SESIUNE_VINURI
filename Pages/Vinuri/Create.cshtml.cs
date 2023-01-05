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
    public class CreateModel : PageModel
    {
        private readonly PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext _context;

        public CreateModel(PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TaraID"] = new SelectList(_context.Set<Tara>(), "ID",
            "Nume");
            return Page();
        }

        [BindProperty]
        public Vin Vin { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vin.Add(Vin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
