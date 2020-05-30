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
    public class UlogaController : ApiController
    {
        private IUlogeService _service;
        private UlogaMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public UlogaController()
        {
            this._service = new UlogaService();
            this._mapper = new UlogaMapper();
        }

        // GET: api/uloga
        [HttpGet]
        public IQueryable<Uloga> GetUlogas()
        {
            return db.Uloga;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetUlogaCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapUlogaCollectionToBasicUlogaCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/uloga/count")]
        public IHttpActionResult GetUlogaCount()
        {
            var result = _service.GetUlogaCount();
            return Ok(result);
        }

        // GET: api/uloga/5
        public IHttpActionResult GetUloga(int id)
        {
            var result = _service.GetUloga(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapUlogaToBasicUloga(result);
            return Ok(response);
        }

        // POST: api/uloga
        public IHttpActionResult PostUloga([FromBody] UlogaView uloga)
        {
            var model = _mapper.MapUlogaViewToUloga(uloga);
            var result = _service.AddUloga(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/uloga/5
        public IHttpActionResult Put([FromBody] UlogaView uloga)
        {
            var model = _mapper.MapUlogaViewToUloga(uloga);
            var result = _service.UpdateUloga(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/uloga/5
        public bool Delete(int id)
        {
            try
            {
                var uloga = db.Uloga.SingleOrDefault(v => v.Id == id);
                if (uloga != null)
                {
                    db.Uloga.Remove(uloga);
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