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
    public class OsobljeController : ApiController
    {
        private IOsobljeService _service;
        private OsobljeMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public OsobljeController()
        {
            this._service = new OsobljeService();
            this._mapper = new OsobljeMapper();
        }

        // GET: api/osoblje
        [HttpGet]
        public IQueryable<Osoblje> GetOsobljes()
        {
            return db.Osoblje;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetOsobljeCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapOsobljeCollectionToBasicOsobljeCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/osoblje/count")]
        public IHttpActionResult GetOsobljeCount()
        {
            var result = _service.GetOsobljeCount();
            return Ok(result);
        }

        // GET: api/osoblje/5
        public IHttpActionResult GetOsoblje(int id)
        {
            var result = _service.GetOsoblje(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapOsobljeToBasicOsoblje(result);
            return Ok(response);
        }

        // POST: api/osoblje
        public IHttpActionResult PostOsoblje([FromBody] OsobljeView osoblje)
        {
            var model = _mapper.MapOsobljeViewToOsoblje(osoblje);
            var result = _service.AddOsoblje(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/osoblje/5
        public IHttpActionResult Put([FromBody] OsobljeView osoblje)
        {
            var model = _mapper.MapOsobljeViewToOsoblje(osoblje);
            var result = _service.UpdateOsoblje(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/osoblje/5
        public bool Delete(int id)
        {
            try
            {
                var osoblje = db.Osoblje.SingleOrDefault(v => v.Id == id);
                if (osoblje != null)
                {
                    db.Osoblje.Remove(osoblje);
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
