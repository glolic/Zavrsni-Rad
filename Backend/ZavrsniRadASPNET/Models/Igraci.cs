using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Igraci
    {
        public Igraci()
        {
            IgraciPlacanja = new HashSet<IgraciPlacanja>();
        }

        public int Id { get; set; }
        public int? PozicijaId { get; set; }
        public int? OsobaId { get; set; }
        public int BrojDresa { get; set; }
        public int? MomcadId { get; set; }

        public virtual Momcadi Momcad { get; set; }
        public virtual Osoba Osoba { get; set; }
        public virtual Pozicija Pozicija { get; set; }
        public virtual ICollection<IgraciPlacanja> IgraciPlacanja { get; set; }
    }
}
