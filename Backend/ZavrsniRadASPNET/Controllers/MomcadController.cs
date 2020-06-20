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
    public class MomcadController : ApiController
    {
        private IMomcadService _service;
        private MomcadMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public MomcadController()
        {
            this._service = new MomcadService();
            this._mapper = new MomcadMapper();
        }

        // GET: api/momcad
        [HttpGet]
        public IQueryable<Momcadi> GetMomcads()
        {
            return db.Momcadi;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetMomcadCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapMomcadCollectionToBasicMomcadCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/momcad/count")]
        public IHttpActionResult GetMomcadCount()
        {
            var result = _service.GetMomcadCount();
            return Ok(result);
        }

        // GET: api/momcad/5
        public IHttpActionResult GetMomcad(int id)
        {
            var result = _service.GetMomcad(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapMomcadToBasicMomcad(result);
            return Ok(response);
        }

        // POST: api/momcad
        public IHttpActionResult PostMomcad([FromBody] MomcadView momcad)
        {
            var model = _mapper.MapMomcadViewToMomcad(momcad);
            var result = _service.AddMomcad(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/momcad/5
        public IHttpActionResult Put([FromBody] MomcadView momcad)
        {
            var model = _mapper.MapMomcadViewToMomcad(momcad);
            var result = _service.UpdateMomcad(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/momcad/5
        public bool Delete(int id)
        {
            try
            {
                var momcad = db.Momcadi.SingleOrDefault(v => v.Id == id);
                if (momcad != null)
                {
                    db.Momcadi.Remove(momcad);
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
