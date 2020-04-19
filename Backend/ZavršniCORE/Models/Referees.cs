using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class Referees
    {
        public Referees()
        {
            Games = new HashSet<Games>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Oib { get; set; }

        public virtual ICollection<Games> Games { get; set; }
    }
}
