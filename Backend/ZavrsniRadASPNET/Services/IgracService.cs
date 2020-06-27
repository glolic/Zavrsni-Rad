using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class IgracService : IIgracService
    {
        private HokejKlubContext _context;

        public IgracService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetIgracCount()
        {
            var query = _context.Igraci.Count();
            return query;
        }

        public List<Igraci> GetIgracCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortIgracCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Igraci> SortIgracCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Igraci.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Igraci.OrderBy(v => v.Id) : _context.Igraci.OrderByDescending(v => v.Osoba.Ime);
                case "brojDresa":
                    return sortOrder.Equals("asc") ? _context.Igraci.OrderBy(v => v.BrojDresa) : _context.Igraci.OrderByDescending(v => v.BrojDresa);
                case "osoba":
                    return sortOrder.Equals("asc") ? _context.Igraci.OrderBy(v => v.Osoba.Ime) : _context.Igraci.OrderByDescending(v => v.Osoba.Ime);
                case "pozicija":
                    return sortOrder.Equals("asc") ? _context.Igraci.OrderBy(v => v.Pozicija.Naziv) : _context.Igraci.OrderByDescending(v => v.Pozicija.Naziv);
                case "momcad":
                    return sortOrder.Equals("asc") ? _context.Igraci.OrderBy(v => v.Momcad.Naziv) : _context.Igraci.OrderByDescending(v => v.Momcad.Naziv);
                default:
                    return _context.Igraci.OrderBy(v => v.Osoba.Ime);
            }
        }

        public Igraci GetIgrac(int ID)
        {
            var query = _context.Igraci.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddIgrac(Igraci igrac)
        {
            try
            {
                _context.Igraci.Add(igrac);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteIgrac(int ID)
        {
            try
            {
                var igrac = _context.Igraci.SingleOrDefault(v => v.Id == ID);
                if (igrac != null)
                {
                    _context.Igraci.Remove(igrac);
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
        public bool UpdateIgrac(Igraci igrac)
        {
            int id;
            var igrac1 = _context.Igraci.SingleOrDefault(v => v.Id == igrac.Id);
            id = igrac.Id;
            igrac1.BrojDresa = igrac.BrojDresa;
            igrac1.OsobaId = igrac.OsobaId;
            igrac1.PozicijaId = igrac.PozicijaId;
            igrac1.MomcadId = igrac.MomcadId;

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