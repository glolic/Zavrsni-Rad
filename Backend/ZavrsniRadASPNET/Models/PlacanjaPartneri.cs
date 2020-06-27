using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class PlacanjaPartneri
    {
        public int Id { get; set; }
        public int? PartnerId { get; set; }
        public string RazlogPlacanja { get; set; }
        public double Iznos { get; set; }
        public DateTime? DatumPlacanja { get; set; }

        public virtual Partneri Partner { get; set; }
    }
}
