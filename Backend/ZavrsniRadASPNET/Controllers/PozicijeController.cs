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
    public class PozicijeController : ApiController
    {
        private IPozicijaService _service;
        private PozicijaMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public PozicijeController()
        {
            this._service = new PozicijaService();
            this._mapper = new PozicijaMapper();
        }

        // GET: api/pozicija
        [HttpGet]
        public IQueryable<Pozicija> GetPozicijas()
        {
            return db.Pozicija;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetPozicijaCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapPozicijaCollectionToBasicPozicijaCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/Pozicije/count")]
        public IHttpActionResult GetPozicijaCount()
        {
            var result = _service.GetPozicijaCount();
            return Ok(result);
        }

        // GET: api/pozicija/5
        public IHttpActionResult GetPozicija(int id)
        {
            var result = _service.GetPozicija(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapPozicijaToBasicPozicija(result);
            return Ok(response);
        }

        // POST: api/pozicija
        public IHttpActionResult PostPozicija([FromBody] PozicijaView pozicija)
        {
            var model = _mapper.MapPozicijaViewToPozicija(pozicija);
            var result = _service.AddPozicija(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/pozicija/5
        public IHttpActionResult Put([FromBody] PozicijaView pozicija)
        {
            var model = _mapper.MapPozicijaViewToPozicija(pozicija);
            var result = _service.UpdatePozicija(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/pozicija/5
        public bool Delete(int id)
        {
            try
            {
                var pozicija = db.Pozicija.SingleOrDefault(v => v.Id == id);
                if (pozicija != null)
                {
                    db.Pozicija.Remove(pozicija);
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
