using System;
using System.Collections.Generic;

namespace PRO_BackendApp_v2.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string Email { get; set; }
    }
}
