using System;
using System.Collections.Generic;

namespace PRO_BackendApp_v2.Models
{
    public partial class Platnosc
    {
        public Platnosc()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPlatnosc { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
