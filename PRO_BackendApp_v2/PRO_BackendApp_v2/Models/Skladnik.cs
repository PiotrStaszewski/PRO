using System;
using System.Collections.Generic;

namespace PRO_BackendApp_v2.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            SkladaSie = new HashSet<SkladaSie>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }
        public decimal Koszt { get; set; }

        public virtual ICollection<SkladaSie> SkladaSie { get; set; }
    }
}
