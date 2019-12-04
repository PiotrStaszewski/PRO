using System;
using System.Collections.Generic;

namespace PRO_BackendApp.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdKlienta { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public int Telefon { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
