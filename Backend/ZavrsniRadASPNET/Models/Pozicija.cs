using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Pozicija
    {
        public Pozicija()
        {
            Igraci = new HashSet<Igraci>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Igraci> Igraci { get; set; }
    }
}
