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
    public class DrzaveController : ApiController
    {
        private IDrzaveService _service;
        private DrzaveMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public DrzaveController()
        {
            this._service = new DrzaveService();
            this._mapper = new DrzaveMapper();
        }

        // GET: api/drzave
        [HttpGet]
        public IQueryable<Drzave> GetDrzave()
        {
            return db.Drzave;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetDrzavaCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapDrzaveCollectionToBasicDrzaveCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/drzave/count")]
        public IHttpActionResult GetDrzaveCount()
        {
            var result = _service.GetDrzavaCount();
            return Ok(result);
        }

        // GET: api/drzave/5
        public IHttpActionResult GetDrzave(int id)
        {
            var result = _service.GetDrzava(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapDrzaveToBasicDrzave(result);
            return Ok(response);
        }

        // POST: api/drzave
        public IHttpActionResult PostDrzave([FromBody] DrzaveView drzava)
        {
            var model = _mapper.MapDrzaveViewToDrzave(drzava);
            var result = _service.AddDrzava(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/drzave/5
        public IHttpActionResult Put([FromBody] DrzaveView drzava)
        {
            var model = _mapper.MapDrzaveViewToDrzave(drzava);
            var result = _service.UpdateDrzava(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/drzave/5
        public bool Delete(int id)
        {
            try
            {
                var drzava = db.Drzave.SingleOrDefault(v => v.Id == id);
                if (drzava != null)
                {
                    db.Drzave.Remove(drzava);
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
