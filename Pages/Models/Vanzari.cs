namespace PROIECT_SESIUNE_VINURI.Pages.Models
{
    public class Vanzari
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }

        public int? VinID { get; set; }
        public Vin? Vin { get; set; }

    }
}
