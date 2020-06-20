using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class OsobaService : IOsobaService
    {
        private HokejKlubContext _context;

        public OsobaService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetOsobaCount()
        {
            var query = _context.Osoba.Count();
            return query;
        }

        public List<Osoba> GetOsobaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortOsobaCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Osoba> SortOsobaCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Osoba.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Osoba.OrderBy(v => v.Id) : _context.Osoba.OrderByDescending(v => v.Ime);
                case "ime":
                    return sortOrder.Equals("asc") ? _context.Osoba.OrderBy(v => v.Ime) : _context.Osoba.OrderByDescending(v => v.Ime);
                case "prezime":
                    return sortOrder.Equals("asc") ? _context.Osoba.OrderBy(v => v.Prezime) : _context.Osoba.OrderByDescending(v => v.Prezime);
                case "datumRodenja":
                    return sortOrder.Equals("asc") ? _context.Osoba.OrderBy(v => v.DatumRodenja) : _context.Osoba.OrderByDescending(v => v.DatumRodenja);
                case "oib":
                    return sortOrder.Equals("asc") ? _context.Osoba.OrderBy(v => v.Oib) : _context.Osoba.OrderByDescending(v => v.Oib);
                case "spol":
                    return sortOrder.Equals("asc") ? _context.Osoba.OrderBy(v => v.Spol.Naziv) : _context.Osoba.OrderByDescending(v => v.Spol.Naziv);
                case "drzavaRodenja":
                    return sortOrder.Equals("asc") ? _context.Osoba.OrderBy(v => v.DrzavaRodenja.NazivDrzave) : _context.Osoba.OrderByDescending(v => v.DrzavaRodenja.NazivDrzave);
                case "uloga":
                    return sortOrder.Equals("asc") ? _context.Osoba.OrderBy(v => v.Uloga.Naziv) : _context.Osoba.OrderByDescending(v => v.Uloga.Naziv);
                default:
                    return _context.Osoba.OrderBy(v => v.Ime);
            }
        }

        public Osoba GetOsoba(int ID)
        {
            var query = _context.Osoba.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddOsoba(Osoba osoba)
        {
            try
            {
                _context.Osoba.Add(osoba);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteOsoba(int ID)
        {
            try
            {
                var osoba = _context.Osoba.SingleOrDefault(v => v.Id == ID);
                if (osoba != null)
                {
                    _context.Osoba.Remove(osoba);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool UpdateOsoba(Osoba osoba)
        {
            int id;
            var osoba1 = _context.Osoba.SingleOrDefault(v => v.Id == osoba.Id);
            id = osoba.Id;
            osoba1.Ime = osoba.Ime;
            osoba1.Prezime = osoba.Prezime;
            osoba1.Oib = osoba.Oib;
            osoba1.DatumRodenja = osoba.DatumRodenja;
            osoba1.SpolId = osoba.SpolId;
            osoba1.DrzavaRodenjaId = osoba.DrzavaRodenjaId;
            osoba1.UlogaId = osoba.UlogaId;

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}