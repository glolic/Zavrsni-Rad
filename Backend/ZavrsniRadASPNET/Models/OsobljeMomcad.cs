using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class OsobljeMomcad
    {
        public int Id { get; set; }
        public int? OsobljeId { get; set; }
        public int? MomcadId { get; set; }

        public virtual Momcadi Momcad { get; set; }
        public virtual Osoblje Osoblje { get; set; }
    }
}
