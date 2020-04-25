using System;
using System.Collections.Generic;

namespace ZavrsniRadBackend.Models
{
    public partial class Natjecanja
    {
        public Natjecanja()
        {
            Utakmice = new HashSet<Utakmice>();
        }

        public int Id { get; set; }
        public string ImeNatjecanja { get; set; }
        public int? DrzavaId { get; set; }

        public virtual Drzave Drzava { get; set; }
        public virtual ICollection<Utakmice> Utakmice { get; set; }
    }
}
