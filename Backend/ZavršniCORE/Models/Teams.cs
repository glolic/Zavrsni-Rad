using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class Teams
    {
        public Teams()
        {
            GamesTeam1 = new HashSet<Games>();
            GamesTeam2 = new HashSet<Games>();
            Players = new HashSet<Players>();
            Staff = new HashSet<Staff>();
        }

        public int Id { get; set; }
        public string TeamName { get; set; }
        public int? StadiumId { get; set; }

        public virtual Stadiums Stadium { get; set; }
        public virtual ICollection<Games> GamesTeam1 { get; set; }
        public virtual ICollection<Games> GamesTeam2 { get; set; }
        public virtual ICollection<Players> Players { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
