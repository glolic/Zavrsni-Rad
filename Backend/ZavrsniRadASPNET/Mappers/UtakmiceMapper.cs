using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class UtakmiceMapper
    {
        public UtakmiceView MapUtakmiceToBasicUtakmice(Utakmice utakmica)
        {
            var result = new UtakmiceView
            {
                Id = utakmica.Id,
                Rezultat = utakmica.Rezultat,
                DatumUtakmice = utakmica.DatumUtakmice,
                BrojPosjetitelja = utakmica.BrojPosjetitelja,
                Momcad1 = new MomcadView()
                {
                    Id = utakmica.Momcad1.Id,
                    Naziv = utakmica.Momcad1.Naziv,
                    Klub = new KlubView()
                    {
                        Id = utakmica.Momcad1.Klub.Id,
                        Naziv = utakmica.Momcad1.Klub.Naziv,
                        GodinaOsnivanja = utakmica.Momcad1.Klub.GodinaOsnivanja,
                        SjedisteKluba = new LokacijaView()
                        {
                            Id = utakmica.Momcad1.Klub.SjedisteKluba.Id,
                            Adresa = utakmica.Momcad1.Klub.SjedisteKluba.Adresa,
                            Drzava = new DrzaveView()
                            {
                                Id = utakmica.Momcad1.Klub.SjedisteKluba.Drzava.Id,
                                NazivDrzave = utakmica.Momcad1.Klub.SjedisteKluba.Drzava.NazivDrzave,
                                Oznaka = utakmica.Momcad1.Klub.SjedisteKluba.Drzava.Oznaka
                            }
                        },
                        Stadion = new StadionView()
                        {
                            Id = utakmica.Momcad1.Klub.Stadion.Id,
                            Naziv = utakmica.Momcad1.Klub.Stadion.Naziv,
                            Kapacitet = utakmica.Momcad1.Klub.Stadion.Kapacitet,
                            Lokacija = new LokacijaView()
                            {
                                Id = utakmica.Momcad1.Klub.Stadion.Lokacija.Id,
                                Adresa = utakmica.Momcad1.Klub.Stadion.Lokacija.Adresa,
                                Drzava = new DrzaveView()
                                {
                                    Id = utakmica.Momcad1.Klub.Stadion.Lokacija.Drzava.Id,
                                    NazivDrzave = utakmica.Momcad1.Klub.Stadion.Lokacija.Drzava.NazivDrzave,
                                    Oznaka = utakmica.Momcad1.Klub.Stadion.Lokacija.Drzava.Oznaka
                                }
                            }
                        }
                    }
                },
                Momcad2 = new MomcadView()
                {
                    Id = utakmica.Momcad2.Id,
                    Naziv = utakmica.Momcad2.Naziv,
                    Klub = new KlubView()
                    {
                        Id = utakmica.Momcad2.Klub.Id,
                        Naziv = utakmica.Momcad2.Klub.Naziv,
                        GodinaOsnivanja = utakmica.Momcad2.Klub.GodinaOsnivanja,
                        SjedisteKluba = new LokacijaView()
                        {
                            Id = utakmica.Momcad2.Klub.SjedisteKluba.Id,
                            Adresa = utakmica.Momcad2.Klub.SjedisteKluba.Adresa,
                            Drzava = new DrzaveView()
                            {
                                Id = utakmica.Momcad2.Klub.SjedisteKluba.Drzava.Id,
                                NazivDrzave = utakmica.Momcad2.Klub.SjedisteKluba.Drzava.NazivDrzave,
                                Oznaka = utakmica.Momcad2.Klub.SjedisteKluba.Drzava.Oznaka
                            }
                        },
                        Stadion = new StadionView()
                        {
                            Id = utakmica.Momcad2.Klub.Stadion.Id,
                            Naziv = utakmica.Momcad2.Klub.Stadion.Naziv,
                            Kapacitet = utakmica.Momcad2.Klub.Stadion.Kapacitet,
                            Lokacija = new LokacijaView()
                            {
                                Id = utakmica.Momcad2.Klub.Stadion.Lokacija.Id,
                                Adresa = utakmica.Momcad2.Klub.Stadion.Lokacija.Adresa,
                                Drzava = new DrzaveView()
                                {
                                    Id = utakmica.Momcad2.Klub.Stadion.Lokacija.Drzava.Id,
                                    NazivDrzave = utakmica.Momcad2.Klub.Stadion.Lokacija.Drzava.NazivDrzave,
                                    Oznaka = utakmica.Momcad2.Klub.Stadion.Lokacija.Drzava.Oznaka
                                }
                            }
                        }
                    }
                },
                Natjecanje = new NatjecanjaView()
                {
                    Id = utakmica.Natjecanje.Id,
                    ImeNatjecanja = utakmica.Natjecanje.ImeNatjecanja,
                    Drzava = new DrzaveView()
                    {
                        Id = utakmica.Natjecanje.Drzava.Id,
                        NazivDrzave = utakmica.Natjecanje.Drzava.NazivDrzave,
                        Oznaka = utakmica.Natjecanje.Drzava.Oznaka
                    }
                }
            };
            return result;
        }

        public IEnumerable<UtakmiceView> MapUtakmiceCollectionToBasicUtakmiceCollection(IEnumerable<Utakmice> utakmicaCollection)
        {
            var result = new List<UtakmiceView>();
            foreach (Utakmice utakmica in utakmicaCollection)
            {
                var basicUtakmice = this.MapUtakmiceToBasicUtakmice(utakmica);
                result.Add(basicUtakmice);
            }

            return result;
        }

        public Utakmice MapUtakmiceViewToUtakmice(UtakmiceView view)
        {
            var result = new Utakmice()
            {
                Id = view.Id,
                Rezultat = view.Rezultat,
                BrojPosjetitelja = view.BrojPosjetitelja,
                DatumUtakmice = view.DatumUtakmice,
                Momcad1Id = view.Momcad1.Id,
                Momcad2Id = view.Momcad2.Id,
                NatjecanjeId = view.Natjecanje.Id
        };
            return result;
        }
    }
}