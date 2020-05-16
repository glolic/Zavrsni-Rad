using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class IgracMomcad
    {
        public int Id { get; set; }
        public int? IgracId { get; set; }
        public int? MomcadId { get; set; }

        public virtual Igraci Igrac { get; set; }
        public virtual Momcadi Momcad { get; set; }
    }
}
