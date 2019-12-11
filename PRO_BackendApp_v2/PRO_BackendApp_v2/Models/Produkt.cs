using System;
using System.Collections.Generic;

namespace PRO_BackendApp_v2.Models
{
    public partial class Produkt
    {
        public Produkt()
        {
            ZawieraProdukty = new HashSet<ZawieraProdukty>();
        }

        public int IdProduktu { get; set; }
        public int PrzepisIdPrzepisu { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public virtual Przepis PrzepisIdPrzepisuNavigation { get; set; }
        public virtual ICollection<ZawieraProdukty> ZawieraProdukty { get; set; }
    }
}
