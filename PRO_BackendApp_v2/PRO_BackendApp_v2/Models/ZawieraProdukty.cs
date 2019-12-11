using System;
using System.Collections.Generic;

namespace PRO_BackendApp_v2.Models
{
    public partial class ZawieraProdukty
    {
        public int IdZawiera { get; set; }
        public int ZamowienieSzczegolyIdSzczegoly { get; set; }
        public int ProduktIdProduktu { get; set; }

        public virtual Produkt ProduktIdProduktuNavigation { get; set; }
        public virtual ZamowienieSzczegoly ZamowienieSzczegolyIdSzczegolyNavigation { get; set; }
    }
}
