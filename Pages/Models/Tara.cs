using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PROIECT_SESIUNE_VINURI.Pages.Models
{
    public class Tara
    {
        public int ID { get; set; }
        [Display(Name = "Tara Origine:")]
        public string? Nume { get; set; }
        public ICollection<Vin>? Vinuri { get; set; }
    }
}
