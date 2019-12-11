using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRO_BackendApp_v2.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdKlienta { get; set; }
        [Required(ErrorMessage ="Imię jest wymagane")]
        [MaxLength(50, ErrorMessage ="Za długie imię")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(50, ErrorMessage = "Za długie nazwisko")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Email jest wymagany")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon jest wymagany")]
        public int Telefon { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
