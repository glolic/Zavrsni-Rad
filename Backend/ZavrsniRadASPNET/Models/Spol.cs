using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Spol
    {
        public Spol()
        {
            Osoba = new HashSet<Osoba>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Osoba> Osoba { get; set; }
    }
}
