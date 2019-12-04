using System;
using System.Collections.Generic;

namespace PRO_BackendApp.Models
{
    public partial class Produkt
    {
        public Produkt()
        {
            Przepis = new HashSet<Przepis>();
            ZamowienieSzczegoly = new HashSet<ZamowienieSzczegoly>();
        }

        public int IdProduktu { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<Przepis> Przepis { get; set; }
        public virtual ICollection<ZamowienieSzczegoly> ZamowienieSzczegoly { get; set; }
    }
}
