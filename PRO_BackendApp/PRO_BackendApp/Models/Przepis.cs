using System;
using System.Collections.Generic;

namespace PRO_BackendApp.Models
{
    public partial class Przepis
    {
        public int IdPrzepisu { get; set; }
        public int ProduktIdProduktu { get; set; }
        public int SkladnikIdSkladnik { get; set; }
        public int Ilosc { get; set; }

        public virtual Produkt ProduktIdProduktuNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
    }
}
