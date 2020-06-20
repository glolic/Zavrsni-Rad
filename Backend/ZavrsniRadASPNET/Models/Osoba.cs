using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Osoba
    {
        public Osoba()
        {
            Igraci = new HashSet<Igraci>();
            Osoblje = new HashSet<Osoblje>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string Oib { get; set; }
        public int? SpolId { get; set; }
        public int? DrzavaRodenjaId { get; set; }
        public int? UlogaId { get; set; }

        public virtual Drzave DrzavaRodenja { get; set; }
        public virtual Spol Spol { get; set; }
        public virtual Uloga Uloga { get; set; }
        public virtual ICollection<Igraci> Igraci { get; set; }
        public virtual ICollection<Osoblje> Osoblje { get; set; }
    }
}
