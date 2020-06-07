using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZavrsniRadASPNET.Mappers;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Services;
using ZavrsniRadASPNET.ServiceInterfaces;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Controllers
{
    public class NatjecanjaController : ApiController
    {
        private INatjecanjaService _service;
        private NatjecanjaMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public NatjecanjaController()
        {
            this._service = new NatjecanjaService();
            this._mapper = new NatjecanjaMapper();
        }

        // GET: api/natjecanja
        [HttpGet]
        public IQueryable<Natjecanja> GetNatjecanjas()
        {
            return db.Natjecanja;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetNatjecanjaCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapNatjecanjaCollectionToBasicNatjecanjaCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/natjecanja/count")]
        public IHttpActionResult GetNatjecanjaCount()
        {
            var result = _service.GetNatjecanjaCount();
            return Ok(result);
        }

        // GET: api/natjecanja/5
        public IHttpActionResult GetNatjecanja(int id)
        {
            var result = _service.GetNatjecanja(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapNatjecanjaToBasicNatjecanja(result);
            return Ok(response);
        }

        // POST: api/natjecanja
        public IHttpActionResult PostNatjecanja([FromBody] NatjecanjaView natjecanja)
        {
            var model = _mapper.MapNatjecanjaViewToNatjecanja(natjecanja);
            var result = _service.AddNatjecanja(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/natjecanja/5
        public IHttpActionResult Put([FromBody] NatjecanjaView natjecanja)
        {
            var model = _mapper.MapNatjecanjaViewToNatjecanja(natjecanja);
            var result = _service.UpdateNatjecanja(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/natjecanja/5
        public bool Delete(int id)
        {
            try
            {
                var natjecanja = db.Natjecanja.SingleOrDefault(v => v.Id == id);
                if (natjecanja != null)
                {
                    db.Natjecanja.Remove(natjecanja);
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
