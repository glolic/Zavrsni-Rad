using System;
using System.Collections.Generic;

namespace ZavrsniRadBackend.Models
{
    public partial class DrzavaOsobe
    {
        public int Id { get; set; }
        public int? OsobaId { get; set; }
        public int? DrzavaId { get; set; }

        public virtual Drzave Drzava { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
}
