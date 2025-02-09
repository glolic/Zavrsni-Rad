﻿using System;
using System.Collections.Generic;

namespace ZavrsniRadASPNET.Models
{
    public partial class Lokacija
    {
        public Lokacija()
        {
            Partneri = new HashSet<Partneri>();
        }

        public int Id { get; set; }
        public string Adresa { get; set; }
        public int? DrzavaId { get; set; }

        public virtual Drzave Drzava { get; set; }
        public virtual ICollection<Partneri> Partneri { get; set; }
    }
}
