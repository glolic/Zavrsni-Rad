using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.Views
{
    public class OsobaView
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string Oib { get; set; }
        public SpolView Spol { get; set; }
        public DrzaveView DrzavaRodenja { get; set; }
        public UlogaView Uloga { get; set; }
    }
}