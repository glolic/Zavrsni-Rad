using System;
using System.Collections.Generic;

namespace ZavrsniRadBackend.Models
{
    public partial class PlacanjaPartneri
    {
        public int Id { get; set; }
        public int? PartnerId { get; set; }
        public string RazlogPlacanja { get; set; }
        public double? Iznos { get; set; }

        public virtual Partneri Partner { get; set; }
    }
}
