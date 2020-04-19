using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class Stadiums
    {
        public Stadiums()
        {
            Teams = new HashSet<Teams>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public int? Capacity { get; set; }

        public virtual Locations Location { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
