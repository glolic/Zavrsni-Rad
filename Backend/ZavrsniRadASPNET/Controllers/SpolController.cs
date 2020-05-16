using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ZavrsniRadASPNET.Mappers;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Services;
using ZavrsniRadASPNET.ServiceInterfaces;
using ZavrsniRadASPNET.Views;

namespace CaritasAPI2.Controllers
{
    public class SpolController : ApiController
    {
        private ISpolService _service;
        private SpolMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public SpolController()
        {
            this._service = new SpolService();
            this._mapper = new SpolMapper();
        }

        // GET: api/spol
        [HttpGet]
        public IQueryable<Spol> GetSpols()
        {
            return db.Spol;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetSpolCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapSpolCollectionToBasicSpolCollection(result); 
            return Ok(response);
        }

        [HttpGet]
        [Route("api/spol/count")]
        public IHttpActionResult GetSpolCount()
        {
            var result = _service.GetSpolCount();
            return Ok(result);
        }

        // GET: api/spol/5
        public IHttpActionResult GetSpol(int id)
        {
            var result = _service.GetSpol(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapSpolToBasicSpol(result);
            return Ok(response);
        }

        // POST: api/spol
        public IHttpActionResult PostSpol([FromBody] SpolView spol)
        {
            var model = _mapper.MapSpolViewToSpol(spol);
            var result = _service.AddSpol(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/spol/5
        public IHttpActionResult Put([FromBody] SpolView spol)
        {
            var model = _mapper.MapSpolViewToSpol(spol);
            var result = _service.UpdateSpol(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/spol/5
        public bool Delete(int id)
        {
            try
            {
                var spol = db.Spol.SingleOrDefault(v => v.Id == id);
                if (spol != null)
                {
                    db.Spol.Remove(spol);
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