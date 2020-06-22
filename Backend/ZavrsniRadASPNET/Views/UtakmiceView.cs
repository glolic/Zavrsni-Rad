using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZavrsniRadASPNET.Views
{
    public class UtakmiceView
    {
        public int Id { get; set; }
        public DateTime DatumUtakmice { get; set; }
        public string Rezultat { get; set; }
        public int BrojPosjetitelja { get; set; }
        public MomcadView Momcad1 { get; set; }
        public MomcadView Momcad2 { get; set; }
        public NatjecanjaView Natjecanje { get; set; }
    }
}