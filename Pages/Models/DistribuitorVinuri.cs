namespace PROIECT_SESIUNE_VINURI.Pages.Models
{
    public class DistribuitorVinuri
    {
        public int ID { get; set; }
        public int VinID { get; set; }
        public Vin Vin { get; set; }
        public int DistribuitorID { get; set; }
        public Distribuitor Distribuitor { get; set; }
        


}
}
