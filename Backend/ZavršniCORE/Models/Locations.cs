using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class Locations
    {
        public Locations()
        {
            Partners = new HashSet<Partners>();
            Stadiums = new HashSet<Stadiums>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Partners> Partners { get; set; }
        public virtual ICollection<Stadiums> Stadiums { get; set; }
    }
}
