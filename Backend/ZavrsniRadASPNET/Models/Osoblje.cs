using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Osoblje
    {
        public Osoblje()
        {
            OsobljeMomcad = new HashSet<OsobljeMomcad>();
        }

        public int Id { get; set; }
        public int? OsobaId { get; set; }

        public virtual Osoba Osoba { get; set; }
        public virtual ICollection<OsobljeMomcad> OsobljeMomcad { get; set; }
    }
}
