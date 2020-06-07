using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class StadionMapper
    {
        public StadionView MapStadionToBasicStadion(Stadioni stadion)
        {
            var result = new StadionView
            {
                Id = stadion.Id,
                Naziv = stadion.Naziv,
                Kapacitet = stadion.Kapacitet,
                Lokacija = new LokacijaView()
                {
                    Id = stadion.Lokacija.Id,
                    Adresa = stadion.Lokacija.Adresa,
                    Drzava = new DrzaveView()
                    {
                        Id = stadion.Lokacija.Drzava.Id,
                        NazivDrzave = stadion.Lokacija.Drzava.NazivDrzave,
                        Oznaka = stadion.Lokacija.Drzava.Oznaka
                    }
                }
            };
            return result;
        }

        public IEnumerable<StadionView> MapStadionCollectionToBasicStadionCollection(IEnumerable<Stadioni> stadionCollection)
        {
            var result = new List<StadionView>();
            foreach (Stadioni stadion in stadionCollection)
            {
                var basicStadion = this.MapStadionToBasicStadion(stadion);
                result.Add(basicStadion);
            }

            return result;
        }

        public Stadioni MapStadionViewToStadion(StadionView view)
        {
            var result = new Stadioni()
            {
                Id = view.Id,
                Naziv = view.Naziv,
                Kapacitet = view.Kapacitet,
                LokacijaId = view.Lokacija.Id
            };
            return result;
        }
    }
}