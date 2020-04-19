using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class Players
    {
        public Players()
        {
            PlayerPayments = new HashSet<PlayerPayments>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Position { get; set; }
        public int? TeamId { get; set; }

        public virtual Teams Team { get; set; }
        public virtual ICollection<PlayerPayments> PlayerPayments { get; set; }
    }
}
