using System;
using System.Collections.Generic;

namespace ZavrsniRadBackend.Models
{
    public partial class Drzave
    {
        public Drzave()
        {
            DrzavaOsobe = new HashSet<DrzavaOsobe>();
            Lokacija = new HashSet<Lokacija>();
            Natjecanja = new HashSet<Natjecanja>();
            Osoba = new HashSet<Osoba>();
        }

        public int Id { get; set; }
        public string NazivDrzave { get; set; }
        public string Oznaka { get; set; }

        public virtual ICollection<DrzavaOsobe> DrzavaOsobe { get; set; }
        public virtual ICollection<Lokacija> Lokacija { get; set; }
        public virtual ICollection<Natjecanja> Natjecanja { get; set; }
        public virtual ICollection<Osoba> Osoba { get; set; }
    }
}
