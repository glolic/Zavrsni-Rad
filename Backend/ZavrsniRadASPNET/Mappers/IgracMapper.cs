using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class IgracMapper
    {
        public IgracView MapIgracToBasicIgrac(Igraci igrac)
        {
            var result = new IgracView
            {
                Id = igrac.Id,
                brojDresa = igrac.BrojDresa,
                Pozicija = new PozicijaView()
                {
                    Id = igrac.Pozicija.Id,
                    Naziv = igrac.Pozicija.Naziv
                },
                Osoba = new OsobaView()
                {
                    Id = igrac.Osoba.Id,
                    Ime = igrac.Osoba.Ime,
                    Prezime = igrac.Osoba.Prezime,
                    Oib = igrac.Osoba.Oib,
                    DatumRodenja = igrac.Osoba.DatumRodenja,
                    DrzavaRodenja = new DrzaveView()
                    {
                        Id = igrac.Osoba.DrzavaRodenja.Id,
                        NazivDrzave = igrac.Osoba.DrzavaRodenja.NazivDrzave,
                        Oznaka = igrac.Osoba.DrzavaRodenja.Oznaka
                    },
                    Spol = new SpolView()
                    {
                        Id = igrac.Osoba.Spol.Id,
                        Naziv = igrac.Osoba.Spol.Naziv
                    },
                    Uloga = new UlogaView()
                    {
                        Id = igrac.Osoba.Uloga.Id,
                        Naziv = igrac.Osoba.Uloga.Naziv
                    }
                },
                Momcad = new MomcadView()
                {
                    Id = igrac.Momcad.Id,
                    Naziv = igrac.Momcad.Naziv,
                    Klub = new KlubView()
                    {
                        Id = igrac.Momcad.Klub.Id,
                        Naziv = igrac.Momcad.Klub.Naziv
                    }
                }
            };
            return result;
        }

        public IEnumerable<IgracView> MapIgracCollectionToBasicIgracCollection(IEnumerable<Igraci> igracCollection)
        {
            var result = new List<IgracView>();
            foreach (Igraci igrac in igracCollection)
            {
                var basicIgrac = this.MapIgracToBasicIgrac(igrac);
                result.Add(basicIgrac);
            }

            return result;
        }

        public Igraci MapIgracViewToIgrac(IgracView view)
        {
            var result = new Igraci()
            {
                Id = view.Id,
                BrojDresa = view.brojDresa,
                PozicijaId = view.Pozicija.Id,
                OsobaId = view.Osoba.Id,
                MomcadId = view.Momcad.Id
            };
            return result;
        }
    }
}