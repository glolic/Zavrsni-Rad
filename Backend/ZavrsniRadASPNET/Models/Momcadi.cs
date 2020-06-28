using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Momcadi
    {
        public Momcadi()
        {
            Igraci = new HashSet<Igraci>();
            Osoblje = new HashSet<Osoblje>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? KlubId { get; set; }

        public virtual Klub Klub { get; set; }
        public virtual ICollection<Igraci> Igraci { get; set; }
        public virtual ICollection<Osoblje> Osoblje { get; set; }
    }
}
