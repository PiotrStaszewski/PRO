using System;
using System.Collections.Generic;

namespace PRO_BackendApp_v2.Models
{
    public partial class Przepis
    {
        public Przepis()
        {
            Produkt = new HashSet<Produkt>();
            SkladaSie = new HashSet<SkladaSie>();
        }

        public int IdPrzepisu { get; set; }

        public virtual ICollection<Produkt> Produkt { get; set; }
        public virtual ICollection<SkladaSie> SkladaSie { get; set; }
    }
}
