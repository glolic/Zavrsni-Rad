using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class SpolService : ISpolService
    {
        private HokejKlubContext _context;

        public SpolService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetSpolCount()
        {
            var query = _context.Spol.Count();
            return query;
        }

        public List<Spol> GetSpolCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortSpolCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Spol> SortSpolCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Spol.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "naziv":
                    return sortOrder.Equals("asc") ? _context.Spol.OrderBy(v => v.Naziv) : _context.Spol.OrderByDescending(v => v.Naziv);
                default:
                    return _context.Spol.OrderBy(v => v.Id);
            }
        }

        public Spol GetSpol(int ID)
        {
            var query = _context.Spol.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddSpol(Spol spol)
        {
            try
            {
                _context.Spol.Add(spol);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteSpol(int ID)
        {
            try
            {
                var user = _context.Spol.SingleOrDefault(v => v.Id == ID);
                if (user != null)
                {
                    _context.Spol.Remove(user);
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
        public bool UpdateSpol(Spol spol)
        {
            int id;
            var nUser = _context.Spol.SingleOrDefault(v => v.Id == spol.Id);
            id = spol.Id;
            nUser.Naziv = spol.Naziv;

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