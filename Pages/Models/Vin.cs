using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PROIECT_SESIUNE_VINURI.Pages.Models
{
    public class Vin
    {
        public int ID { get; set; }
        [Display(Name = "Denumire Vin")]
        public string Nume { get; set; }
        [Display(Name = "An:")]
        public int An { get; set; }
        [Display(Name = "Tip:")]

        public string Tip { get; set; }
        [Display(Name = "Culoare:")]
        public string Culoare { get; set; }
        [Display(Name = "Pret/Lei:")]

        public int Pret { get; set; }

        public int TaraID { get; set; }

        public Tara Tara { get; set; }
    }
}
