namespace PROIECT_SESIUNE_VINURI.Pages.Models
{
    public class Distribuitor
    {
        public int ID { get; set; }
        public string Nume_Firma { get; set; }
        public ICollection<DistribuitorVinuri>? DistribuitorDeVinuri { get; set; }
        public ICollection<Vin>? Vinuri { get; set; }



    }
}
