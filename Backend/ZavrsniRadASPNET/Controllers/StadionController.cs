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
    public class StadionController : ApiController
    {
        private IStadionService _service;
        private StadionMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public StadionController()
        {
            this._service = new StadionService();
            this._mapper = new StadionMapper();
        }

        // GET: api/stadion
        [HttpGet]
        public IQueryable<Stadioni> GetStadions()
        {
            return db.Stadioni;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetStadionCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapStadionCollectionToBasicStadionCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/stadion/count")]
        public IHttpActionResult GetStadionCount()
        {
            var result = _service.GetStadionCount();
            return Ok(result);
        }

        // GET: api/stadion/5
        public IHttpActionResult GetStadion(int id)
        {
            var result = _service.GetStadion(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapStadionToBasicStadion(result);
            return Ok(response);
        }

        // POST: api/stadion
        public IHttpActionResult PostStadion([FromBody] StadionView stadion)
        {
            var model = _mapper.MapStadionViewToStadion(stadion);
            var result = _service.AddStadion(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/stadion/5
        public IHttpActionResult Put([FromBody] StadionView stadion)
        {
            var model = _mapper.MapStadionViewToStadion(stadion);
            var result = _service.UpdateStadion(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/stadion/5
        public bool Delete(int id)
        {
            try
            {
                var stadion = db.Stadioni.SingleOrDefault(v => v.Id == id);
                if (stadion != null)
                {
                    db.Stadioni.Remove(stadion);
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
