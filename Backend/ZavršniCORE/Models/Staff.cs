using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? TeamId { get; set; }

        public virtual Teams Team { get; set; }
    }
}
