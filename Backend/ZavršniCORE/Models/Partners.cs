using System;
using System.Collections.Generic;

namespace ZavršniCORE.Models
{
    public partial class Partners
    {
        public Partners()
        {
            PartnerPayments = new HashSet<PartnerPayments>();
        }

        public int Id { get; set; }
        public string PartnerName { get; set; }
        public int? LocationId { get; set; }

        public virtual Locations Location { get; set; }
        public virtual ICollection<PartnerPayments> PartnerPayments { get; set; }
    }
}
