using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class OsobaMapper
    {
        public OsobaView MapOsobaToBasicOsoba(Osoba osoba)
        {
            var result = new OsobaView
            {
                Id = osoba.Id,
                Ime = osoba.Ime,
                Prezime = osoba.Prezime,
                Oib = osoba.Oib,
                DatumRodenja = osoba.DatumRodenja,
                DrzavaRodenja = new DrzaveView()
                {
                    Id = osoba.DrzavaRodenja.Id,
                    NazivDrzave = osoba.DrzavaRodenja.NazivDrzave,
                    Oznaka = osoba.DrzavaRodenja.Oznaka
                },
                Spol = new SpolView()
                {
                    Id = osoba.Spol.Id,
                    Naziv = osoba.Spol.Naziv
                },
                Uloga = new UlogaView()
                {
                    Id = osoba.Uloga.Id,
                    Naziv = osoba.Uloga.Naziv
                }
            };
            return result;
        }

        public IEnumerable<OsobaView> MapOsobaCollectionToBasicOsobaCollection(IEnumerable<Osoba> osobaCollection)
        {
            var result = new List<OsobaView>();
            foreach (Osoba osoba in osobaCollection)
            {
                var basicOsoba = this.MapOsobaToBasicOsoba(osoba);
                result.Add(basicOsoba);
            }

            return result;
        }

        public Osoba MapOsobaViewToOsoba(OsobaView view)
        {
            var result = new Osoba()
            {
                Id = view.Id,
                Ime = view.Ime,
                Prezime = view.Prezime,
                Oib = view.Oib,
                DatumRodenja = view.DatumRodenja,
                SpolId = view.Spol.Id,
                UlogaId = view.Uloga.Id,
                DrzavaRodenjaId = view.DrzavaRodenja.Id
            };
            return result;
        }
    }
}