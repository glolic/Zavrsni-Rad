using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class LokacijaService : ILokacijaService
    {
        private HokejKlubContext _context;

        public LokacijaService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetLokacijaCount()
        {
            var query = _context.Lokacija.Count();
            return query;
        }

        public List<Lokacija> GetLokacijaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortLokacijaCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Lokacija> SortLokacijaCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Lokacija.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Lokacija.OrderBy(v => v.Id) : _context.Lokacija.OrderByDescending(v => v.Adresa);
                case "adresa":
                    return sortOrder.Equals("asc") ? _context.Lokacija.OrderBy(v => v.Adresa) : _context.Lokacija.OrderByDescending(v => v.Adresa);
                case "drzava":
                    return sortOrder.Equals("asc") ? _context.Lokacija.OrderBy(v => v.Drzava.NazivDrzave) : _context.Lokacija.OrderByDescending(v => v.Drzava.NazivDrzave);
                default:
                    return _context.Lokacija.OrderBy(v => v.Adresa);
            }
        }

        public Lokacija GetLokacija(int ID)
        {
            var query = _context.Lokacija.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddLokacija(Lokacija lokacija)
        {
            try
            {
                _context.Lokacija.Add(lokacija);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteLokacija(int ID)
        {
            try
            {
                var lokacija = _context.Lokacija.SingleOrDefault(v => v.Id == ID);
                if (lokacija != null)
                {
                    _context.Lokacija.Remove(lokacija);
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
        public bool UpdateLokacija(Lokacija lokacija)
        {
            int id;
            var lokacija1 = _context.Lokacija.SingleOrDefault(v => v.Id == lokacija.Id);
            id = lokacija.Id;
            lokacija1.Adresa = lokacija.Adresa;
            lokacija.DrzavaId = lokacija.DrzavaId;

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