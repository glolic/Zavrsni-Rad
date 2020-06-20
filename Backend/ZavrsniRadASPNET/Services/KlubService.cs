using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class KlubService : IKlubService
    {
        private HokejKlubContext _context;

        public KlubService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetKlubCount()
        {
            var query = _context.Klub.Count();
            return query;
        }

        public List<Klub> GetKlubCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortKlubCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Klub> SortKlubCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Klub.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Klub.OrderBy(v => v.Id) : _context.Klub.OrderByDescending(v => v.Naziv);
                case "naziv":
                    return sortOrder.Equals("asc") ? _context.Klub.OrderBy(v => v.Naziv) : _context.Klub.OrderByDescending(v => v.Naziv);
                case "godinaOsnivanja":
                    return sortOrder.Equals("asc") ? _context.Klub.OrderBy(v => v.GodinaOsnivanja) : _context.Klub.OrderByDescending(v => v.GodinaOsnivanja);
                case "sjedisteKluba":
                    return sortOrder.Equals("asc") ? _context.Klub.OrderBy(v => v.SjedisteKluba.Adresa) : _context.Klub.OrderByDescending(v => v.SjedisteKluba.Adresa);
                case "stadion":
                    return sortOrder.Equals("asc") ? _context.Klub.OrderBy(v => v.Stadion.Naziv) : _context.Klub.OrderByDescending(v => v.Stadion.Naziv);
                default:
                    return _context.Klub.OrderBy(v => v.Naziv);
            }
        }

        public Klub GetKlub(int ID)
        {
            var query = _context.Klub.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddKlub(Klub klub)
        {
            try
            {
                _context.Klub.Add(klub);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteKlub(int ID)
        {
            try
            {
                var klub = _context.Klub.SingleOrDefault(v => v.Id == ID);
                if (klub != null)
                {
                    _context.Klub.Remove(klub);
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
        public bool UpdateKlub(Klub klub)
        {
            int id;
            var klub1 = _context.Klub.SingleOrDefault(v => v.Id == klub.Id);
            id = klub.Id;
            klub1.Naziv = klub.Naziv;
            klub1.GodinaOsnivanja = klub.GodinaOsnivanja;
            klub1.StadionId = klub.StadionId;
            klub1.SjedisteKlubaId = klub.SjedisteKlubaId;

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