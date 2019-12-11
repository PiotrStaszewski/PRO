using System;
using System.Collections.Generic;

namespace PRO_BackendApp_v2.Models
{
    public partial class ZamowienieSzczegoly
    {
        public ZamowienieSzczegoly()
        {
            Zamowienie = new HashSet<Zamowienie>();
            ZawieraProdukty = new HashSet<ZawieraProdukty>();
        }

        public int IdSzczegoly { get; set; }
        public int PromocjaIdPromocji { get; set; }
        public int Ilosc { get; set; }
        public decimal Cena { get; set; }

        public virtual Promocja PromocjaIdPromocjiNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
        public virtual ICollection<ZawieraProdukty> ZawieraProdukty { get; set; }
    }
}
