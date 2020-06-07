using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Stadioni
    {
        public Stadioni()
        {
            Klub = new HashSet<Klub>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? LokacijaId { get; set; }
        public int Kapacitet { get; set; }

        public virtual Lokacija Lokacija { get; set; }
        public virtual ICollection<Klub> Klub { get; set; }
    }
}
