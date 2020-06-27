using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZavrsniRadASPNET.Views
{
    public class OsobljeView
    {
        public int Id { get; set; }
        public DateTime DatumIstekaDozvole { get; set; }
        public DateTime DatumIzdajeDozvole { get; set; }
        public MomcadView Momcad { get; set; }
        public OsobaView Osoba { get; set; }
    }
}