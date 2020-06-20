using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class KlubMapper
    {
        public KlubView MapKlubToBasicKlub(Klub klub)
        {
            var result = new KlubView
            {
                Id = klub.Id,
                Naziv = klub.Naziv,
                GodinaOsnivanja = klub.GodinaOsnivanja,
                SjedisteKluba = new LokacijaView()
                {
                    Id = klub.SjedisteKluba.Id,
                    Adresa = klub.SjedisteKluba.Adresa,
                    Drzava = new DrzaveView()
                    {
                        Id = klub.SjedisteKluba.Drzava.Id,
                        NazivDrzave = klub.SjedisteKluba.Drzava.NazivDrzave,
                        Oznaka = klub.SjedisteKluba.Drzava.Oznaka
                    }
                },
                Stadion = new StadionView()
                {
                    Id = klub.Stadion.Id,
                    Naziv = klub.Stadion.Naziv,
                    Kapacitet = klub.Stadion.Kapacitet,
                    Lokacija = new LokacijaView()
                    {
                        Id = klub.Stadion.Lokacija.Id,
                        Adresa = klub.Stadion.Lokacija.Adresa,
                        Drzava = new DrzaveView()
                        {
                            Id = klub.Stadion.Lokacija.Drzava.Id,
                            NazivDrzave = klub.Stadion.Lokacija.Drzava.NazivDrzave,
                            Oznaka = klub.Stadion.Lokacija.Drzava.Oznaka
                        }
                    }
                }
            };
            return result;
        }

        public IEnumerable<KlubView> MapKlubCollectionToBasicKlubCollection(IEnumerable<Klub> klubCollection)
        {
            var result = new List<KlubView>();
            foreach (Klub klub in klubCollection)
            {
                var basicKlub = this.MapKlubToBasicKlub(klub);
                result.Add(basicKlub);
            }

            return result;
        }

        public Klub MapKlubViewToKlub(KlubView view)
        {
            var result = new Klub()
            {
                Id = view.Id,
                Naziv = view.Naziv,
                GodinaOsnivanja = view.GodinaOsnivanja,
                SjedisteKlubaId = view.SjedisteKluba.Id,
                StadionId = view.Stadion.Id
            };
            return result;
        }
    }
}