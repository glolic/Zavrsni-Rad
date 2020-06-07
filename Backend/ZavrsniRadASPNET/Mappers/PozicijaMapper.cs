using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class PozicijaMapper
    {
        public PozicijaView MapPozicijaToBasicPozicija(Pozicija pozicija)
        {
            var result = new PozicijaView
            {
                Id = pozicija.Id,
                Naziv = pozicija.Naziv
            };
            return result;
        }

        public IEnumerable<PozicijaView> MapPozicijaCollectionToBasicPozicijaCollection(IEnumerable<Pozicija> pozicijaCollection)
        {
            var result = new List<PozicijaView>();
            foreach (Pozicija pozicija in pozicijaCollection)
            {
                var basicPozicija = this.MapPozicijaToBasicPozicija(pozicija);
                result.Add(basicPozicija);
            }

            return result;
        }

        public Pozicija MapPozicijaViewToPozicija(PozicijaView view)
        {
            var result = new Pozicija()
            {
                Id = view.Id,
                Naziv = view.Naziv
            };
            return result;
        }
    }
}