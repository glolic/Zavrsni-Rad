using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ZavrsniRadASPNET.Mappers;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;
using ZavrsniRadASPNET.Services;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Controllers
{
    public class KlubController : ApiController
    {
        private IKlubService _service;
        private KlubMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public KlubController()
        {
            this._service = new KlubService();
            this._mapper = new KlubMapper();
        }

        // GET: api/klub
        [HttpGet]
        public IQueryable<Klub> GetKlubs()
        {
            return db.Klub;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetKlubCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapKlubCollectionToBasicKlubCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/klub/count")]
        public IHttpActionResult GetKlubCount()
        {
            var result = _service.GetKlubCount();
            return Ok(result);
        }

        // GET: api/klub/5
        public IHttpActionResult GetKlub(int id)
        {
            var result = _service.GetKlub(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapKlubToBasicKlub(result);
            return Ok(response);
        }

        // POST: api/klub
        public IHttpActionResult PostKlub([FromBody] KlubView klub)
        {
            var model = _mapper.MapKlubViewToKlub(klub);
            var result = _service.AddKlub(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/klub/5
        public IHttpActionResult Put([FromBody] KlubView klub)
        {
            var model = _mapper.MapKlubViewToKlub(klub);
            var result = _service.UpdateKlub(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/klub/5
        public bool Delete(int id)
        {
            try
            {
                var klub = db.Klub.SingleOrDefault(v => v.Id == id);
                if (klub != null)
                {
                    db.Klub.Remove(klub);
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