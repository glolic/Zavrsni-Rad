using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZavrsniRadBackend.Models;
using ZavrsniRadBackend.Services;
using ZavrsniRadBackend.SInterfaces;
using ZavrsniRadBackend.Mappers;

namespace ZavrsniRadBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpolController : ControllerBase
    {
        private ISpolService _service;
        private SpolMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        // GET: api/Spol
        [HttpGet]
        public IEnumerable<Spol> Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetSpolCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapSpolCollectionToBasicSpolCollection(result);
            return result;
        }

        [HttpGet]
        [Route("api/spol/Count")]
        public ActionResult GetSpolCount()
        {
            var result = _service.GetSpolCount();
            return Ok(result);
        }

        // GET: api/Spol/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Spol
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Spol/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
