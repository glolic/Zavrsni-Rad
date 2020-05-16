using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Partneri
    {
        public Partneri()
        {
            PlacanjaPartneri = new HashSet<PlacanjaPartneri>();
        }

        public int Id { get; set; }
        public string NazivPartnera { get; set; }
        public int? LokacijaId { get; set; }

        public virtual Lokacija Lokacija { get; set; }
        public virtual ICollection<PlacanjaPartneri> PlacanjaPartneri { get; set; }
    }
}
