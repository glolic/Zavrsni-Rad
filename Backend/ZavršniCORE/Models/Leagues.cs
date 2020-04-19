using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class Leagues
    {
        public int Id { get; set; }
        public string NameOfLeague { get; set; }
        public int? CountryId { get; set; }

        public virtual Countries Country { get; set; }
    }
}
