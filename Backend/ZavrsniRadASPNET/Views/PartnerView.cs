using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZavrsniRadASPNET.Views
{
    public class PartnerView
    {
        public int Id { get; set; }
        public string NazivPartnera { get; set; }
        public LokacijaView Lokacija { get; set; }
    }
}