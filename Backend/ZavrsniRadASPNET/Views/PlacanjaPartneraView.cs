using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZavrsniRadASPNET.Views
{
    public class PlacanjaPartneraView
    {
        public int Id { get; set; }
        public string RazlogPlacanja { get; set; }
        public double Iznos { get; set; }
        public bool Placeno { get; set; }
        public PartnerView Partner { get; set; }
    }
}