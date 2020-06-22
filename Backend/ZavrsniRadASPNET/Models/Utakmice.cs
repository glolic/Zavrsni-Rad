using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Utakmice
    {
        public int Id { get; set; }
        public int? Momcad1Id { get; set; }
        public int? Momcad2Id { get; set; }
        public DateTime DatumUtakmice { get; set; }
        public string Rezultat { get; set; }
        public int? NatjecanjeId { get; set; }
        public int BrojPosjetitelja { get; set; }

        public virtual Momcadi Momcad1 { get; set; }
        public virtual Momcadi Momcad2 { get; set; }
        public virtual Natjecanja Natjecanje { get; set; }
    }
}
