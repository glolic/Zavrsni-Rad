using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class PlayerPayments
    {
        public int Id { get; set; }
        public int? PlayerId { get; set; }
        public double? Amount { get; set; }

        public virtual Players Player { get; set; }
    }
}
