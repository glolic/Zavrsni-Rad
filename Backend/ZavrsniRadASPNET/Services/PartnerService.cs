using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;

namespace ZavrsniRadASPNET.Services
{
    public class PartnerService : IPartneriService
    {
        private HokejKlubContext _context;

        public PartnerService()
        {
            this._context = new HokejKlubContext();
        }

        public int GetPartnerCount()
        {
            var query = _context.Partneri.Count();
            return query;
        }

        public List<Partneri> GetPartnerCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var query = SortPartnerCollection(sortColumn, sortOrder);

            var paginatedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IOrderedQueryable<Partneri> SortPartnerCollection(string sortColumn, string sortOrder)
        {
            if (sortColumn == null || sortOrder == null)
            {
                return _context.Partneri.OrderBy(v => v.Id);
            }

            switch (sortColumn)
            {
                case "id":
                    return sortColumn.Equals("asc") ? _context.Partneri.OrderBy(v => v.Id) : _context.Partneri.OrderByDescending(v => v.Id);
                case "naziv":
                    return sortOrder.Equals("asc") ? _context.Partneri.OrderBy(v => v.NazivPartnera) : _context.Partneri.OrderByDescending(v => v.NazivPartnera);
                case "oznaka":
                    return sortOrder.Equals("asc") ? _context.Partneri.OrderBy(v => v.Lokacija) : _context.Partneri.OrderByDescending(v => v.Lokacija);
                default:
                    return _context.Partneri.OrderBy(v => v.NazivPartnera);
            }
        }

        public Partneri GetPartner(int ID)
        {
            var query = _context.Partneri.SingleOrDefault(v => v.Id == ID);
            return query;
        }
        public bool AddPartner(Partneri partner)
        {
            try
            {
                _context.Partneri.Add(partner);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeletePartner(int ID)
        {
            try
            {
                var partner = _context.Partneri.SingleOrDefault(v => v.Id == ID);
                if (partner != null)
                {
                    _context.Partneri.Remove(partner);
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
        public bool UpdatePartner(Partneri partner)
        {
            int id;
            var partner1 = _context.Partneri.SingleOrDefault(v => v.Id == partner.Id);
            id = partner.Id;
            partner1.NazivPartnera = partner.NazivPartnera;
            partner1.LokacijaId = partner.LokacijaId;

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