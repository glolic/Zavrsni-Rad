using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZavrsniRadASPNET.Mappers;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;
using ZavrsniRadASPNET.Services;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Controllers
{
    public class OsobaController : ApiController
    {
        private IOsobaService _service;
        private OsobaMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public OsobaController()
        {
            this._service = new OsobaService();
            this._mapper = new OsobaMapper();
        }

        // GET: api/osoba
        [HttpGet]
        public IQueryable<Osoba> GetOsobas()
        {
            return db.Osoba;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetOsobaCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapOsobaCollectionToBasicOsobaCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/osoba/count")]
        public IHttpActionResult GetOsobaCount()
        {
            var result = _service.GetOsobaCount();
            return Ok(result);
        }

        // GET: api/osoba/5
        public IHttpActionResult GetOsoba(int id)
        {
            var result = _service.GetOsoba(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapOsobaToBasicOsoba(result);
            return Ok(response);
        }

        // POST: api/osoba
        public IHttpActionResult PostOsoba([FromBody] OsobaView osoba)
        {
            var model = _mapper.MapOsobaViewToOsoba(osoba);
            var result = _service.AddOsoba(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/osoba/5
        public IHttpActionResult Put([FromBody] OsobaView osoba)
        {
            var model = _mapper.MapOsobaViewToOsoba(osoba);
            var result = _service.UpdateOsoba(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/osoba/5
        public bool Delete(int id)
        {
            try
            {
                var osoba = db.Osoba.SingleOrDefault(v => v.Id == id);
                if (osoba != null)
                {
                    db.Osoba.Remove(osoba);
                    db.SaveChanges();
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
    }
}
