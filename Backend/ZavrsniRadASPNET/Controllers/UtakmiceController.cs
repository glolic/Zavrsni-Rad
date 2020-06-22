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
    public class UtakmiceController : ApiController
    {
        private IUtakmiceService _service;
        private UtakmiceMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public UtakmiceController()
        {
            this._service = new UtakmiceService();
            this._mapper = new UtakmiceMapper();
        }

        // GET: api/utakmice
        [HttpGet]
        public IQueryable<Utakmice> GetUtakmices()
        {
            return db.Utakmice;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetUtakmiceCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapUtakmiceCollectionToBasicUtakmiceCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/utakmice/count")]
        public IHttpActionResult GetUtakmiceCount()
        {
            var result = _service.GetUtakmiceCount();
            return Ok(result);
        }

        // GET: api/utakmice/5
        public IHttpActionResult GetUtakmice(int id)
        {
            var result = _service.GetUtakmice(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapUtakmiceToBasicUtakmice(result);
            return Ok(response);
        }

        // POST: api/utakmice
        public IHttpActionResult PostUtakmice([FromBody] UtakmiceView utakmice)
        {
            var model = _mapper.MapUtakmiceViewToUtakmice(utakmice);
            var result = _service.AddUtakmice(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/utakmice/5
        public IHttpActionResult Put([FromBody] UtakmiceView utakmice)
        {
            var model = _mapper.MapUtakmiceViewToUtakmice(utakmice);
            var result = _service.UpdateUtakmice(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/utakmice/5
        public bool Delete(int id)
        {
            try
            {
                var utakmice = db.Utakmice.SingleOrDefault(v => v.Id == id);
                if (utakmice != null)
                {
                    db.Utakmice.Remove(utakmice);
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
