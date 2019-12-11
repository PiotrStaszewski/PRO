using System;
using System.Collections.Generic;

namespace PRO_BackendApp_v2.Models
{
    public partial class Zamowienie
    {
        public int IdZamowienie { get; set; }
        public int KlientIdKlienta { get; set; }
        public int ZamowienieSzczegolyIdSzczegoly { get; set; }
        public int PlatnoscIdPlatnosc { get; set; }
        public int AdresIdAdres { get; set; }
        public int LokalIdLokalu { get; set; }
        public decimal Cena { get; set; }
        public DateTime Data { get; set; }

        public virtual Adres AdresIdAdresNavigation { get; set; }
        public virtual Klient KlientIdKlientaNavigation { get; set; }
        public virtual Lokal LokalIdLokaluNavigation { get; set; }
        public virtual Platnosc PlatnoscIdPlatnoscNavigation { get; set; }
        public virtual ZamowienieSzczegoly ZamowienieSzczegolyIdSzczegolyNavigation { get; set; }
    }
}
