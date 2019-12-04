using System;
using System.Collections.Generic;

namespace PRO_BackendApp.Models
{
    public partial class ZamowienieSzczegoly
    {
        public int IdSzczegoly { get; set; }
        public int ProduktIdProduktu { get; set; }
        public int ZamowienieIdZamowienie { get; set; }
        public int PromocjaIdPromocji { get; set; }
        public int Ilosc { get; set; }
        public decimal Cena { get; set; }

        public virtual Produkt ProduktIdProduktuNavigation { get; set; }
        public virtual Promocja PromocjaIdPromocjiNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamowienieNavigation { get; set; }
    }
}
