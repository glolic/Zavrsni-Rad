using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class OsobljeMapper
    {
        public OsobljeView MapOsobljeToBasicOsoblje(Osoblje osoblje)
        {
            var result = new OsobljeView
            {
                Id = osoblje.Id,
                DatumIstekaDozvole = osoblje.DatumIstekaDozvole,
                DatumIzdajeDozvole = osoblje.DatumIzdajeDozvole,
                Osoba = new OsobaView()
                {
                    Id = osoblje.Osoba.Id,
                    Ime = osoblje.Osoba.Ime,
                    Prezime = osoblje.Osoba.Prezime,
                    Oib = osoblje.Osoba.Oib,
                    DatumRodenja = osoblje.Osoba.DatumRodenja,
                    DrzavaRodenja = new DrzaveView()
                    {
                        Id = osoblje.Osoba.DrzavaRodenja.Id,
                        NazivDrzave = osoblje.Osoba.DrzavaRodenja.NazivDrzave,
                        Oznaka = osoblje.Osoba.DrzavaRodenja.Oznaka
                    },
                    Spol = new SpolView()
                    {
                        Id = osoblje.Osoba.Spol.Id,
                        Naziv = osoblje.Osoba.Spol.Naziv
                    },
                    Uloga = new UlogaView()
                    {
                        Id = osoblje.Osoba.Uloga.Id,
                        Naziv = osoblje.Osoba.Uloga.Naziv
                    }
                },
                Momcad = new MomcadView()
                {
                    Id = osoblje.Momcad.Id,
                    Naziv = osoblje.Momcad.Naziv,
                    Klub = new KlubView()
                    {
                        Id = osoblje.Momcad.Klub.Id,
                        Naziv = osoblje.Momcad.Klub.Naziv
                    }
                }
            };
            return result;
        }

        public IEnumerable<OsobljeView> MapOsobljeCollectionToBasicOsobljeCollection(IEnumerable<Osoblje> osobljeCollection)
        {
            var result = new List<OsobljeView>();
            foreach (Osoblje osoblje in osobljeCollection)
            {
                var basicOsoblje = this.MapOsobljeToBasicOsoblje(osoblje);
                result.Add(basicOsoblje);
            }

            return result;
        }

        public Osoblje MapOsobljeViewToOsoblje(OsobljeView view)
        {
            var result = new Osoblje()
            {
                Id = view.Id,
                DatumIstekaDozvole = view.DatumIstekaDozvole,
                DatumIzdajeDozvole = view.DatumIzdajeDozvole,
                MomcadId = view.Momcad.Id,
                OsobaId = view.Osoba.Id
            };
            return result;
        }
    }
}