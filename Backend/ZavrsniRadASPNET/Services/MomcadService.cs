using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class MomcadService : IMomcadService
    {
        private HokejKlubContext _context;

        public MomcadService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetMomcadCount()
        {
            var query = _context.Momcadi.Count();
            return query;
        }

        public List<Momcadi> GetMomcadCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortMomcadCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Momcadi> SortMomcadCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Momcadi.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Momcadi.OrderBy(v => v.Id) : _context.Momcadi.OrderByDescending(v => v.Naziv);
                case "naziv":
                    return sortOrder.Equals("asc") ? _context.Momcadi.OrderBy(v => v.Naziv) : _context.Momcadi.OrderByDescending(v => v.Naziv);
                case "klub":
                    return sortOrder.Equals("asc") ? _context.Momcadi.OrderBy(v => v.Klub.Naziv) : _context.Momcadi.OrderByDescending(v => v.Klub.Naziv);
                default:
                    return _context.Momcadi.OrderBy(v => v.Naziv);
            }
        }

        public Momcadi GetMomcad(int ID)
        {
            var query = _context.Momcadi.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddMomcad(Momcadi momcad)
        {
            try
            {
                _context.Momcadi.Add(momcad);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteMomcad(int ID)
        {
            try
            {
                var momcad = _context.Momcadi.SingleOrDefault(v => v.Id == ID);
                if (momcad != null)
                {
                    _context.Momcadi.Remove(momcad);
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
        public bool UpdateMomcad(Momcadi momcad)
        {
            int id;
            var momcad1 = _context.Momcadi.SingleOrDefault(v => v.Id == momcad.Id);
            id = momcad.Id;
            momcad1.Naziv = momcad.Naziv;
            momcad1.KlubId = momcad.KlubId;

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