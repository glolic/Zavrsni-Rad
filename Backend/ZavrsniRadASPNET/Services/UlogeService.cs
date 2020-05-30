using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class UlogaService : IUlogeService
    {
        private HokejKlubContext _context;

        public UlogaService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetUlogaCount()
        {
            var query = _context.Uloga.Count();
            return query;
        }

        public List<Uloga> GetUlogaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortUlogaCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Uloga> SortUlogaCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Uloga.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Uloga.OrderBy(v => v.Id) : _context.Uloga.OrderByDescending(v => v.Naziv);
                case "naziv":
                    return sortOrder.Equals("asc") ? _context.Uloga.OrderBy(v => v.Naziv) : _context.Uloga.OrderByDescending(v => v.Naziv);
                default:
                    return _context.Uloga.OrderBy(v => v.Naziv);
            }
        }

        public Uloga GetUloga(int ID)
        {
            var query = _context.Uloga.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddUloga(Uloga uloga)
        {
            try
            {
                _context.Uloga.Add(uloga);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteUloga(int ID)
        {
            try
            {
                var uloga = _context.Uloga.SingleOrDefault(v => v.Id == ID);
                if (uloga != null)
                {
                    _context.Uloga.Remove(uloga);
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
        public bool UpdateUloga(Uloga uloga)
        {
            int id;
            var uloga1 = _context.Uloga.SingleOrDefault(v => v.Id == uloga.Id);
            id = uloga.Id;
            uloga1.Naziv = uloga.Naziv;

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