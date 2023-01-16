
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROIECT_SESIUNE_VINURI.Data;
namespace PROIECT_SESIUNE_VINURI.Pages.Models
{
    public class DistribuitorVinuriModel:PageModel
    {
        public List<DistribuitorVinuriDat> DistribuitorVinuriDatList;

        public void IncarcaDistribuitorVinuriDat(PROIECT_SESIUNE_VINURIContext context, Vin vin)
        {
            var allDistribuitori = context.Distribuitor;
            var vinDistribuitori = new HashSet<int>(vin.DistribuitoriDeVinuri.Select(c => c.DistribuitorID));
            DistribuitorVinuriDatList = new List<DistribuitorVinuriDat>();
            foreach (var distribuitor in allDistribuitori)
            {
                DistribuitorVinuriDatList.Add(new DistribuitorVinuriDat
                {
                    DistribuitorID = distribuitor.ID,
                    Name = distribuitor.Nume_Firma,
                    Dat = vinDistribuitori.Contains(distribuitor.ID)

                });
                
            }

        }

        public void UpdateDistribuitorVinuri (PROIECT_SESIUNE_VINURIContext context, string[] selectedDistribuitori, Vin vintoUpdate)
        {
            if(selectedDistribuitori == null)
            {
                vintoUpdate.DistribuitoriDeVinuri = new List<DistribuitorVinuri>();
                return;
            }
            var selectedDistribuitoriHS = new HashSet<string>(selectedDistribuitori);
            var vinDistribuitori = new HashSet<int>(vintoUpdate.DistribuitoriDeVinuri.Select(c => c.Distribuitor.ID));
            foreach ( var distribuitor in context.Distribuitor)
            {
                if (selectedDistribuitoriHS.Contains(distribuitor.ID.ToString()))
                {
                    if (!vinDistribuitori.Contains(distribuitor.ID))
                    {
                        vintoUpdate.DistribuitoriDeVinuri.Add(new DistribuitorVinuri
                        {
                            VinID = vintoUpdate.ID,
                            DistribuitorID = distribuitor.ID
                        });
                    }

                }else
                {
                    if (vinDistribuitori.Contains(distribuitor.ID))
                    {
                        DistribuitorVinuri courseToRemove = vintoUpdate.DistribuitoriDeVinuri.SingleOrDefault(i =>i.DistribuitorID == distribuitor.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
