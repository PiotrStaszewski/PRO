using System;
using System.Collections.Generic;

namespace PRO_BackendApp_v2.Models
{
    public partial class SkladaSie
    {
        public int IdSkladaSie { get; set; }
        public int SkladnikIdSkladnik { get; set; }
        public int PrzepisIdPrzepisu { get; set; }
        public int Ilosc { get; set; }

        public virtual Przepis PrzepisIdPrzepisuNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
    }
}
