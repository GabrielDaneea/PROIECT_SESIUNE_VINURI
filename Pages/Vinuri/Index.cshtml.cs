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
    public class IndexModel : PageModel
    {
        private readonly PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext _context;

        public IndexModel(PROIECT_SESIUNE_VINURI.Data.PROIECT_SESIUNE_VINURIContext context)
        {
            _context = context;
        }

        public IList<Vin> Vin { get;set; }
        public AllDataVinuri AllDataVin { get; set; }
        public int VinID { get; set; }
        public int DistribuitorID { get; set; }


        public async Task OnGetAsync(int? id, int? distribuitorID)
        {
            AllDataVin = new AllDataVinuri();

            AllDataVin.Vinuri = await _context.Vin.Include(b => b.Tara)
                .Include(b => b.DistribuitoriDeVinuri).ThenInclude(b => b.Distribuitor).AsNoTracking().OrderBy(b => b.Nume).ToListAsync();
            if(id != null)
            {
                VinID = id.Value;
                Vin vin = AllDataVin.Vinuri.Where(i => i.ID == id.Value).Single();
                AllDataVin.Distribuitori = vin.DistribuitoriDeVinuri.Select(s => s.Distribuitor);
            }

        }
        


    }
}
