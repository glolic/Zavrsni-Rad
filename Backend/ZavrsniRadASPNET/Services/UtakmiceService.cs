using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class UtakmiceService : IUtakmiceService
    {
        private HokejKlubContext _context;

        public UtakmiceService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetUtakmiceCount()
        {
            var query = _context.Utakmice.Count();
            return query;
        }

        public List<Utakmice> GetUtakmiceCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortUtakmiceCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Utakmice> SortUtakmiceCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Utakmice.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Utakmice.OrderBy(v => v.Id) : _context.Utakmice.OrderByDescending(v => v.Momcad1.Naziv);
                case "rezultat":
                    return sortOrder.Equals("asc") ? _context.Utakmice.OrderBy(v => v.Rezultat) : _context.Utakmice.OrderByDescending(v => v.Rezultat);
                case "brojPosjetitelja":
                    return sortOrder.Equals("asc") ? _context.Utakmice.OrderBy(v => v.BrojPosjetitelja) : _context.Utakmice.OrderByDescending(v => v.BrojPosjetitelja);
                case "datumUtakmice":
                    return sortOrder.Equals("asc") ? _context.Utakmice.OrderBy(v => v.DatumUtakmice) : _context.Utakmice.OrderByDescending(v => v.DatumUtakmice);
                case "momcad1":
                    return sortOrder.Equals("asc") ? _context.Utakmice.OrderBy(v => v.Momcad1.Naziv) : _context.Utakmice.OrderByDescending(v => v.Momcad1.Naziv);
                case "momcad2":
                    return sortOrder.Equals("asc") ? _context.Utakmice.OrderBy(v => v.Momcad2.Naziv) : _context.Utakmice.OrderByDescending(v => v.Momcad2.Naziv);
                case "natjecanje":
                    return sortOrder.Equals("asc") ? _context.Utakmice.OrderBy(v => v.Natjecanje.ImeNatjecanja) : _context.Utakmice.OrderByDescending(v => v.Natjecanje.ImeNatjecanja);
                default:
                    return _context.Utakmice.OrderBy(v => v.Momcad1.Naziv);
            }
        }

        public Utakmice GetUtakmice(int ID)
        {
            var query = _context.Utakmice.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddUtakmice(Utakmice utakmica)
        {
            try
            {
                _context.Utakmice.Add(utakmica);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteUtakmice(int ID)
        {
            try
            {
                var utakmica = _context.Utakmice.SingleOrDefault(v => v.Id == ID);
                if (utakmica != null)
                {
                    _context.Utakmice.Remove(utakmica);
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
        public bool UpdateUtakmice(Utakmice utakmica)
        {
            int id;
            var utakmica1 = _context.Utakmice.SingleOrDefault(v => v.Id == utakmica.Id);
            id = utakmica.Id;
            utakmica1.Rezultat = utakmica.Rezultat;
            utakmica1.BrojPosjetitelja = utakmica.BrojPosjetitelja;
            utakmica1.DatumUtakmice = utakmica.DatumUtakmice;
            utakmica1.Momcad1Id = utakmica.Momcad1Id;
            utakmica1.Momcad2Id = utakmica.Momcad2Id;
            utakmica1.NatjecanjeId = utakmica.NatjecanjeId;

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