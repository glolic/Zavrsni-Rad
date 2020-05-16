using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Momcadi
    {
        public Momcadi()
        {
            IgracMomcad = new HashSet<IgracMomcad>();
            OsobljeMomcad = new HashSet<OsobljeMomcad>();
            UtakmiceMomcad1 = new HashSet<Utakmice>();
            UtakmiceMomcad2 = new HashSet<Utakmice>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? KlubId { get; set; }

        public virtual Klub Klub { get; set; }
        public virtual ICollection<IgracMomcad> IgracMomcad { get; set; }
        public virtual ICollection<OsobljeMomcad> OsobljeMomcad { get; set; }
        public virtual ICollection<Utakmice> UtakmiceMomcad1 { get; set; }
        public virtual ICollection<Utakmice> UtakmiceMomcad2 { get; set; }
    }
}
