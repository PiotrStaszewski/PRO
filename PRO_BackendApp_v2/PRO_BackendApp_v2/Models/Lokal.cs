using System;
using System.Collections.Generic;

namespace PRO_BackendApp_v2.Models
{
    public partial class Lokal
    {
        public Lokal()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdLokalu { get; set; }
        public int AdresIdAdres { get; set; }
        public string Nazwa { get; set; }

        public virtual Adres AdresIdAdresNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
