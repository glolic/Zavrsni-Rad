using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class NatjecanjaMapper
    {
        public NatjecanjaView MapNatjecanjaToBasicNatjecanja(Natjecanja natjecanja)
        {
            var result = new NatjecanjaView
            {
                Id = natjecanja.Id,
                ImeNatjecanja = natjecanja.ImeNatjecanja,
                Drzava = new DrzaveView()
                {
                    Id = natjecanja.Drzava.Id,
                    NazivDrzave = natjecanja.Drzava.NazivDrzave,
                    Oznaka = natjecanja.Drzava.Oznaka
                }
            };
            return result;
        }

        public IEnumerable<NatjecanjaView> MapNatjecanjaCollectionToBasicNatjecanjaCollection(IEnumerable<Natjecanja> natjecanjaCollection)
        {
            var result = new List<NatjecanjaView>();
            foreach (Natjecanja natjecanja in natjecanjaCollection)
            {
                var basicNatjecanja = this.MapNatjecanjaToBasicNatjecanja(natjecanja);
                result.Add(basicNatjecanja);
            }

            return result;
        }

        public Natjecanja MapNatjecanjaViewToNatjecanja(NatjecanjaView view)
        {
            var result = new Natjecanja()
            {
                Id = view.Id,
                ImeNatjecanja = view.ImeNatjecanja,
                DrzavaId = view.Drzava.Id
            };
            return result;
        }
    }
}