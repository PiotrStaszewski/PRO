using System;
using System.Collections.Generic;

namespace PRO_BackendApp_v2.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            ZamowienieSzczegoly = new HashSet<ZamowienieSzczegoly>();
        }

        public int IdPromocji { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<ZamowienieSzczegoly> ZamowienieSzczegoly { get; set; }
    }
}
