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
    public class LokacijaController : ApiController
    {
        private ILokacijaService _service;
        private LokacijaMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public LokacijaController()
        {
            this._service = new LokacijaService();
            this._mapper = new LokacijaMapper();
        }

        // GET: api/lokacija
        [HttpGet]
        public IQueryable<Lokacija> GetLokacijas()
        {
            return db.Lokacija;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetLokacijaCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapLokacijaCollectionToBasicLokacijaCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/lokacija/count")]
        public IHttpActionResult GetLokacijaCount()
        {
            var result = _service.GetLokacijaCount();
            return Ok(result);
        }

        // GET: api/lokacija/5
        public IHttpActionResult GetLokacija(int id)
        {
            var result = _service.GetLokacija(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapLokacijaToBasicLokacija(result);
            return Ok(response);
        }

        // POST: api/lokacija
        public IHttpActionResult PostLokacija([FromBody] LokacijaView lokacija)
        {
            var model = _mapper.MapLokacijaViewToLokacija(lokacija);
            var result = _service.AddLokacija(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/lokacija/5
        public IHttpActionResult Put([FromBody] LokacijaView lokacija)
        {
            var model = _mapper.MapLokacijaViewToLokacija(lokacija);
            var result = _service.UpdateLokacija(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/lokacija/5
        public bool Delete(int id)
        {
            try
            {
                var lokacija = db.Lokacija.SingleOrDefault(v => v.Id == id);
                if (lokacija != null)
                {
                    db.Lokacija.Remove(lokacija);
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
