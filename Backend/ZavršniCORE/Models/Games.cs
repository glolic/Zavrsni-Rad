using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class Games
    {
        public int Id { get; set; }
        public int? Team1Id { get; set; }
        public int? Team2Id { get; set; }
        public DateTime? DateOfGame { get; set; }
        public int? Visitors { get; set; }
        public int? RefereeId { get; set; }

        public virtual Referees Referee { get; set; }
        public virtual Teams Team1 { get; set; }
        public virtual Teams Team2 { get; set; }
    }
}
