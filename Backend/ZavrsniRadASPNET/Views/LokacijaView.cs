using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.Views
{
    public class LokacijaView
    {
        public int Id { get; set; }
        public string Adresa { get; set; }
        public DrzaveView Drzava { get; set; }
    }
}