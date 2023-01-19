using PROIECT_SESIUNE_VINURI.Migrations;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PROIECT_SESIUNE_VINURI.Pages.Models
{
    public class User
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        [Display(Name = "Nume intreg")]
        public string? NumeIntreg
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Vanzari>? Borrowings { get; set; }
    }
}

