using System;
using System.Collections.Generic;

namespace PRO_BackendApp.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            Przepis = new HashSet<Przepis>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }
        public decimal Koszt { get; set; }

        public virtual ICollection<Przepis> Przepis { get; set; }
    }
}
