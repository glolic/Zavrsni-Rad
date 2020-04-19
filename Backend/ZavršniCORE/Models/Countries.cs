using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Leagues = new HashSet<Leagues>();
            Locations = new HashSet<Locations>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<Leagues> Leagues { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }
    }
}
