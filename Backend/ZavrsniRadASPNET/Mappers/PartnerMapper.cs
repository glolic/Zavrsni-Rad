using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class PartnerMapper
    {
        public PartnerView MapPartnerToBasicPartner(Partneri partner)
        {
            var result = new PartnerView
            {
                Id = partner.Id,
                NazivPartnera = partner.NazivPartnera,
                Lokacija = new LokacijaView()
                {
                    Id = partner.Lokacija.Id,
                    Adresa = partner.Lokacija.Adresa,
                    Drzava = new DrzaveView()
                    {
                        Id = partner.Lokacija.Drzava.Id,
                        NazivDrzave = partner.Lokacija.Drzava.NazivDrzave
                    }
                }
            };
            return result;
        }

        public IEnumerable<PartnerView> MapPartnerCollectionToBasicPartnerCollection(IEnumerable<Partneri> partneriCollection)
        {
            var result = new List<PartnerView>();
            foreach (Partneri partner in partneriCollection)
            {
                var basicPartneri = this.MapPartnerToBasicPartner(partner);
                result.Add(basicPartneri);
            }

            return result;
        }

        public Partneri MapPartnerViewToPartner(PartnerView view)
        {
            var result = new Partneri()
            {
                Id = view.Id,
                NazivPartnera = view.NazivPartnera,
                LokacijaId = view.Lokacija.Id
            };
            return result;
        }
    }
}