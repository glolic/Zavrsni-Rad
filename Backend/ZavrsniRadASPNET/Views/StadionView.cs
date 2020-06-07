using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZavrsniRadASPNET.Views
{
    public class StadionView
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public LokacijaView Lokacija { get; set; }
    }
}