using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services 
{
    public class PlacanjaPartneraService : IPlacanjaPartneraService
    {
        private HokejKlubContext _context;

        public PlacanjaPartneraService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetPlacanjaPartneriCount()
        {
            var query = _context.PlacanjaPartneri.Count();
            return query;
        }

        public List<PlacanjaPartneri> GetPlacanjaPartneraCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortPlacanjaPartneraCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<PlacanjaPartneri> SortPlacanjaPartneraCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.PlacanjaPartneri.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.PlacanjaPartneri.OrderBy(v => v.Id) : _context.PlacanjaPartneri.OrderByDescending(v => v.Iznos);
                case "iznos":
                    return sortOrder.Equals("asc") ? _context.PlacanjaPartneri.OrderBy(v => v.Iznos) : _context.PlacanjaPartneri.OrderByDescending(v => v.Iznos);
                case "partner":
                    return sortOrder.Equals("asc") ? _context.PlacanjaPartneri.OrderBy(v => v.Partner.NazivPartnera) : _context.PlacanjaPartneri.OrderByDescending(v => v.Partner.NazivPartnera);
                case "placeno":
                    return sortOrder.Equals("asc") ? _context.PlacanjaPartneri.OrderBy(v => v.Placeno) : _context.PlacanjaPartneri.OrderByDescending(v => v.Placeno);
                default:
                    return _context.PlacanjaPartneri.OrderBy(v => v.Iznos);
            }
        }

        public PlacanjaPartneri GetPlacanjaPartner(int ID)
        {
            var query = _context.PlacanjaPartneri.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddPlacanjaPartner(PlacanjaPartneri placanjaPartneri)
        {
            try
            {
                _context.PlacanjaPartneri.Add(placanjaPartneri);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeletePlacanjaPartner(int ID)
        {
            try
            {
                var placanjaPartneri = _context.PlacanjaPartneri.SingleOrDefault(v => v.Id == ID);
                if (placanjaPartneri != null)
                {
                    _context.PlacanjaPartneri.Remove(placanjaPartneri);
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
        public bool UpdatePlacanjaPartnera(PlacanjaPartneri placanjaPartneri)
        {
            int id;
            var placanjaPartneri1 = _context.PlacanjaPartneri.SingleOrDefault(v => v.Id == placanjaPartneri.Id);
            id = placanjaPartneri.Id;
            placanjaPartneri1.Iznos= placanjaPartneri.Iznos;
            placanjaPartneri1.PartnerId = placanjaPartneri.PartnerId;
            placanjaPartneri1.RazlogPlacanja = placanjaPartneri.RazlogPlacanja;
            placanjaPartneri1.Placeno = placanjaPartneri.Placeno;

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