using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Stadioni
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? LokacijaId { get; set; }
        public int Kapacitet { get; set; }

        public virtual Lokacija Lokacija { get; set; }
    }
}
