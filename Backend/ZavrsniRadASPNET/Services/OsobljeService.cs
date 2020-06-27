using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class OsobljeService : IOsobljeService
    {
        private HokejKlubContext _context;

        public OsobljeService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetOsobljeCount()
        {
            var query = _context.Osoblje.Count();
            return query;
        }

        public List<Osoblje> GetOsobljeCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortOsobljeCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Osoblje> SortOsobljeCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Osoblje.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Osoblje.OrderBy(v => v.Id) : _context.Osoblje.OrderByDescending(v => v.Id);
                case "datumIstekaDozvole":
                    return sortOrder.Equals("asc") ? _context.Osoblje.OrderBy(v => v.DatumIstekaDozvole) : _context.Osoblje.OrderByDescending(v => v.DatumIstekaDozvole);
                case "dozvolaZaRad":
                    return sortOrder.Equals("asc") ? _context.Osoblje.OrderBy(v => v.DatumIzdajeDozvole) : _context.Osoblje.OrderByDescending(v => v.DatumIzdajeDozvole);
                case "momcad":
                    return sortOrder.Equals("asc") ? _context.Osoblje.OrderBy(v => v.Momcad.Naziv) : _context.Osoblje.OrderByDescending(v => v.Momcad.Naziv);
                case "osoba":
                    return sortOrder.Equals("asc") ? _context.Osoblje.OrderBy(v => v.Osoba.Prezime) : _context.Osoblje.OrderByDescending(v => v.Osoba.Prezime);
                default:
                    return _context.Osoblje.OrderBy(v => v.Osoba.Prezime);
            }
        }

        public Osoblje GetOsoblje(int ID)
        {
            var query = _context.Osoblje.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddOsoblje(Osoblje osoblje)
        {
            try
            {
                _context.Osoblje.Add(osoblje);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteOsoblje(int ID)
        {
            try
            {
                var osoblje = _context.Osoblje.SingleOrDefault(v => v.Id == ID);
                if (osoblje != null)
                {
                    _context.Osoblje.Remove(osoblje);
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
        public bool UpdateOsoblje(Osoblje osoblje)
        {
            int id;
            var osoblje1 = _context.Osoblje.SingleOrDefault(v => v.Id == osoblje.Id);
            id = osoblje.Id;
            osoblje1.DatumIstekaDozvole = osoblje.DatumIstekaDozvole;
            osoblje1.DatumIzdajeDozvole = osoblje.DatumIzdajeDozvole;
            osoblje1.MomcadId = osoblje.MomcadId;
            osoblje1.OsobaId = osoblje.OsobaId;

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