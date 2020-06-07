using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.Views
{
    public class NatjecanjaView
    {
        public int Id { get; set; }
        public string ImeNatjecanja { get; set; }
        public DrzaveView Drzava { get; set; }
    }
}