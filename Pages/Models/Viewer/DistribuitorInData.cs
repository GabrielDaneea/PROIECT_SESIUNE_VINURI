using System.Security.Policy;


namespace PROIECT_SESIUNE_VINURI.Pages.Models.Viewer
{
    public class DistribuitorInData
    {
        public IEnumerable<Distribuitor> Distribuitori { get; set; }
        public IEnumerable<Vin> Vinuri { get; set; }

    }
}
