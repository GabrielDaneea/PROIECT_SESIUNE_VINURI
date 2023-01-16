namespace PROIECT_SESIUNE_VINURI.Pages.Models
{
    public class AllDataVinuri
    {
        public IEnumerable<Vin> Vinuri { get; set; }
        public IEnumerable<Distribuitor> Distribuitori { get; set; }
        public IEnumerable<DistribuitorVinuri> DistribuitoriDeVinuri { get; set; }
    }
}
