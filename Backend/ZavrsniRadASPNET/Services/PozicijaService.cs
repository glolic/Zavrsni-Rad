using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class PozicijaService : IPozicijaService
    {
        private HokejKlubContext _context;

        public PozicijaService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetPozicijaCount()
        {
            var query = _context.Pozicija.Count();
            return query;
        }

        public List<Pozicija> GetPozicijaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortPozicijaCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Pozicija> SortPozicijaCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Pozicija.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Pozicija.OrderBy(v => v.Id) : _context.Pozicija.OrderByDescending(v => v.Naziv);
                case "naziv":
                    return sortOrder.Equals("asc") ? _context.Pozicija.OrderBy(v => v.Naziv) : _context.Pozicija.OrderByDescending(v => v.Naziv);
                default:
                    return _context.Pozicija.OrderBy(v => v.Naziv);
            }
        }

        public Pozicija GetPozicija(int ID)
        {
            var query = _context.Pozicija.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddPozicija(Pozicija pozicija)
        {
            try
            {
                _context.Pozicija.Add(pozicija);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeletePozicija(int ID)
        {
            try
            {
                var pozicija = _context.Pozicija.SingleOrDefault(v => v.Id == ID);
                if (pozicija != null)
                {
                    _context.Pozicija.Remove(pozicija);
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
        public bool UpdatePozicija(Pozicija pozicija)
        {
            int id;
            var pozicija1 = _context.Pozicija.SingleOrDefault(v => v.Id == pozicija.Id);
            id = pozicija.Id;
            pozicija1.Naziv = pozicija.Naziv;

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