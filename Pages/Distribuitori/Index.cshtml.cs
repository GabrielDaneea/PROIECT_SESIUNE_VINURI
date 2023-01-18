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

namespace PROIECT_SESIUNE_VINURI.Pages.Distribuitori
{
    public class IndexModel : PageModel
    {
        private readonly PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext _context;

        public IndexModel(PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext context)
        {
            _context = context;
        }

        public IList<Distribuitor> Distribuitor { get;set; } = default!;

        
        public DistribuitorInData DistribuitorData { get; set; }
        public int DistribuitorID { get; set; }
        public int VinID { get; set; }

        public async Task OnGetAsync(int? id, int? vinID)
        {
            DistribuitorData = new DistribuitorInData();
            DistribuitorData.Distribuitori = await _context.Distribuitor.Include(i => i.Vinuri).OrderBy(i => i.Nume_Firma).ToListAsync();
            if (id != null)
            {
                DistribuitorID = id.Value;
                Distribuitor distribuitor = DistribuitorData.Distribuitori.Where(i => i.ID == id.Value).Single();
                DistribuitorData.Vinuri = distribuitor.Vinuri;
            }
        }
    }
}
