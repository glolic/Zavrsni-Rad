using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZavrsniRadASPNET.Views
{
    public class IgracView
    {
        public int Id { get; set; }
        public int brojDresa { get; set; }
        public PozicijaView Pozicija { get; set; }
        public OsobaView Osoba { get; set; }
    }
}