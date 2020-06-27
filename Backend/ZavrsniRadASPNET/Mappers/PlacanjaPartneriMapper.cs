using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class PlacanjaPartneriMapper
    {
        public PlacanjaPartneraView MapPlacanjaPartneriToBasicPlacanjaPartneri(PlacanjaPartneri placanjaPartneri)
        {
            var result = new PlacanjaPartneraView
            {
                Id = placanjaPartneri.Id,
                Iznos = placanjaPartneri.Iznos,
                RazlogPlacanja = placanjaPartneri.RazlogPlacanja,
                DatumPlacanja = placanjaPartneri.DatumPlacanja,
                Partner = new PartnerView()
                {
                    Id = placanjaPartneri.Partner.Id,
                    NazivPartnera = placanjaPartneri.Partner.NazivPartnera
                }
            };
            return result;
        }

        public IEnumerable<PlacanjaPartneraView> MapPlacanjaPartneriCollectionToBasicPlacanjaPartneriCollection(IEnumerable<PlacanjaPartneri> placanjaPartneriCollection)
        {
            var result = new List<PlacanjaPartneraView>();
            foreach (PlacanjaPartneri placanjaPartneri in placanjaPartneriCollection)
            {
                var basicPlacanjaPartneri = this.MapPlacanjaPartneriToBasicPlacanjaPartneri(placanjaPartneri);
                result.Add(basicPlacanjaPartneri);
            }

            return result;
        }

        public PlacanjaPartneri MapPlacanjaPartneraViewToPlacanjaPartneri(PlacanjaPartneraView view)
        {
            var result = new PlacanjaPartneri()
            {
                Id = view.Id,
                Iznos = view.Iznos,
                RazlogPlacanja = view.RazlogPlacanja,
                DatumPlacanja = view.DatumPlacanja,
                PartnerId = view.Partner.Id
            };
            return result;
        }
    }
}