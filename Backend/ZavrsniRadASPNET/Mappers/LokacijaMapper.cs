using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class LokacijaMapper
    {
        public LokacijaView MapLokacijaToBasicLokacija(Lokacija lokacija)
        {
            var result = new LokacijaView
            {
                Id = lokacija.Id,
                Adresa = lokacija.Adresa,
                Drzava = new DrzaveView()
                {
                    Id = lokacija.Drzava.Id,
                    NazivDrzave = lokacija.Drzava.NazivDrzave
                }
            };
            return result;
        }

        public IEnumerable<LokacijaView> MapLokacijaCollectionToBasicLokacijaCollection(IEnumerable<Lokacija> lokacijaCollection)
        {
            var result = new List<LokacijaView>();
            foreach (Lokacija lokacija in lokacijaCollection)
            {
                var basicLokacija = this.MapLokacijaToBasicLokacija(lokacija);
                result.Add(basicLokacija);
            }

            return result;
        }

        public Lokacija MapLokacijaViewToLokacija(LokacijaView view)
        {
            var result = new Lokacija()
            {
                Id = view.Id,
                Adresa = view.Adresa,
                DrzavaId = view.Drzava.Id
            };
            return result;
        }
    }
}