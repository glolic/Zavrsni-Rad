using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Osoblje
    {
        public int Id { get; set; }
        public int? OsobaId { get; set; }
        public int? MomcadId { get; set; }
        public DateTime DatumIzdajeDozvole { get; set; }
        public DateTime DatumIstekaDozvole { get; set; }

        public virtual Momcadi Momcad { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
}
