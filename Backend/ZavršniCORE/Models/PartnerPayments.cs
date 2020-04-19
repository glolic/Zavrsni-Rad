using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class PartnerPayments
    {
        public int Id { get; set; }
        public int? PartnerId { get; set; }
        public double? Amount { get; set; }

        public virtual Partners Partner { get; set; }
    }
}
