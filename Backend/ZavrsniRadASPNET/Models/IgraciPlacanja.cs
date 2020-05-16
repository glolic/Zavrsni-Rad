using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class IgraciPlacanja
    {
        public int Id { get; set; }
        public int? IgracId { get; set; }
        public string RazlogPlacanja { get; set; }
        public double? Iznos { get; set; }

        public virtual Igraci Igrac { get; set; }
    }
}
