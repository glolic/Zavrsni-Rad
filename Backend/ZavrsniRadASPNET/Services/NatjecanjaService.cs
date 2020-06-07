using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class NatjecanjaService : INatjecanjaService
    {
        private HokejKlubContext _context;

        public NatjecanjaService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetNatjecanjaCount()
        {
            var query = _context.Natjecanja.Count();
            return query;
        }

        public List<Natjecanja> GetNatjecanjaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortNatjecanjaCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Natjecanja> SortNatjecanjaCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Natjecanja.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Natjecanja.OrderBy(v => v.Id) : _context.Natjecanja.OrderByDescending(v => v.ImeNatjecanja);
                case "imeNatjecanja":
                    return sortOrder.Equals("asc") ? _context.Natjecanja.OrderBy(v => v.ImeNatjecanja) : _context.Natjecanja.OrderByDescending(v => v.ImeNatjecanja);
                case "drzava":
                    return sortOrder.Equals("asc") ? _context.Natjecanja.OrderBy(v => v.Drzava.NazivDrzave) : _context.Natjecanja.OrderByDescending(v => v.Drzava.NazivDrzave);
                default:
                    return _context.Natjecanja.OrderBy(v => v.ImeNatjecanja);
            }
        }

        public Natjecanja GetNatjecanja(int ID)
        {
            var query = _context.Natjecanja.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddNatjecanja(Natjecanja natjecanja)
        {
            try
            {
                _context.Natjecanja.Add(natjecanja);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteNatjecanja(int ID)
        {
            try
            {
                var natjecanja = _context.Natjecanja.SingleOrDefault(v => v.Id == ID);
                if (natjecanja != null)
                {
                    _context.Natjecanja.Remove(natjecanja);
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
        public bool UpdateNatjecanja(Natjecanja natjecanja)
        {
            int id;
            var natjecanja1 = _context.Natjecanja.SingleOrDefault(v => v.Id == natjecanja.Id);
            id = natjecanja.Id;
            natjecanja1.ImeNatjecanja = natjecanja.ImeNatjecanja;
            natjecanja1.DrzavaId = natjecanja.DrzavaId;

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