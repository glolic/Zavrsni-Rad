using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZavrsniRadASPNET.Views
{
    public class KlubView
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int GodinaOsnivanja { get; set; }
        public LokacijaView SjedisteKluba { get; set; }
        public StadionView Stadion { get; set; }
    }
}