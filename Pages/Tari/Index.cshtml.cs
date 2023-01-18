using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PROIECT_SESIUNE_VINURI.Data;
using PROIECT_SESIUNE_VINURI.Pages.Models;
using PROIECT_SESIUNE_VINURI.Pages.Models.Viewer;

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
        public TaraInData TaraData { get; set; }
        public int TaraID { get; set; }
        public int VinID { get; set; }

        public async Task OnGetAsync(int? id, int? vinID)
        {
            TaraData = new TaraInData();
            TaraData.Tari = await _context.Tara.Include(i => i.Vinuri).OrderBy(i => i.Nume).ToListAsync();
            if (id != null)
            {
                TaraID = id.Value;
                Tara tara = TaraData.Tari.Where(i => i.ID == id.Value).Single();
                TaraData.Vinuri = tara.Vinuri;
            }
        }
    }
}
