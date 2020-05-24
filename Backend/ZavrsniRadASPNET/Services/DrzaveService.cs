using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class DrzaveService : IDrzaveService
    {
        private HokejKlubContext _context;

        public DrzaveService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetDrzavaCount()
        {
            var query = _context.Drzave.Count();
            return query;
        }

        public List<Drzave> GetDrzavaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortDrzavaCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Drzave> SortDrzavaCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Drzave.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Drzave.OrderBy(v => v.Id) : _context.Drzave.OrderByDescending(v => v.Id);
                case "naziv":
                    return sortOrder.Equals("asc") ? _context.Drzave.OrderBy(v => v.NazivDrzave) : _context.Drzave.OrderByDescending(v => v.NazivDrzave);
                case "oznaka":
                    return sortOrder.Equals("asc") ? _context.Drzave.OrderBy(v => v.Oznaka) : _context.Drzave.OrderByDescending(v => v.Oznaka);
                default:
                    return _context.Drzave.OrderBy(v => v.NazivDrzave);
            }
        }

        public Drzave GetDrzava(int ID)
        {
            var query = _context.Drzave.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddDrzava(Drzave drzava)
        {
            try
            {
                _context.Drzave.Add(drzava);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteDrzava(int ID)
        {
            try
            {
                var drzava = _context.Drzave.SingleOrDefault(v => v.Id == ID);
                if (drzava != null)
                {
                    _context.Drzave.Remove(drzava);
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
        public bool UpdateDrzava(Drzave drzava)
        {
            int id;
            var drzava1 = _context.Drzave.SingleOrDefault(v => v.Id == drzava.Id);
            id = drzava.Id;
            drzava1.NazivDrzave = drzava.NazivDrzave;
            drzava1.Oznaka = drzava.Oznaka;

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