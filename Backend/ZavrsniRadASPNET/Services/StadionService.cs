using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class StadionService : IStadionService
    {
        private HokejKlubContext _context;

        public StadionService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetStadionCount()
        {
            var query = _context.Stadioni.Count();
            return query;
        }

        public List<Stadioni> GetStadionCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortStadionCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Stadioni> SortStadionCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Stadioni.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Stadioni.OrderBy(v => v.Id) : _context.Stadioni.OrderByDescending(v => v.Naziv);
                case "naziv":
                    return sortOrder.Equals("asc") ? _context.Stadioni.OrderBy(v => v.Naziv) : _context.Stadioni.OrderByDescending(v => v.Naziv);
                case "kapacitet":
                    return sortOrder.Equals("asc") ? _context.Stadioni.OrderBy(v => v.Kapacitet) : _context.Stadioni.OrderByDescending(v => v.Kapacitet);
                case "lokacija":
                    return sortOrder.Equals("asc") ? _context.Stadioni.OrderBy(v => v.Lokacija.Adresa) : _context.Stadioni.OrderByDescending(v => v.Lokacija.Adresa);
                default:
                    return _context.Stadioni.OrderBy(v => v.Naziv);
            }
        }

        public Stadioni GetStadion(int ID)
        {
            var query = _context.Stadioni.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddStadion(Stadioni stadion)
        {
            try
            {
                _context.Stadioni.Add(stadion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteStadion(int ID)
        {
            try
            {
                var stadion = _context.Stadioni.SingleOrDefault(v => v.Id == ID);
                if (stadion != null)
                {
                    _context.Stadioni.Remove(stadion);
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
        public bool UpdateStadion(Stadioni stadion)
        {
            int id;
            var stadion1 = _context.Stadioni.SingleOrDefault(v => v.Id == stadion.Id);
            id = stadion.Id;
            stadion1.Naziv = stadion.Naziv;
            stadion1.Kapacitet = stadion.Kapacitet;
            stadion1.LokacijaId = stadion.LokacijaId;

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