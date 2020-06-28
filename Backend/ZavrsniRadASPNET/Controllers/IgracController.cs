using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Forms.VisualStyles;
using ZavrsniRadASPNET.Mappers;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.ServiceInterfaces;
using ZavrsniRadASPNET.Services;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Controllers
{
    public class IgracController : ApiController
    {
        private IIgracService _service;
        private IgracMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public IgracController()
        {
            this._service = new IgracService();
            this._mapper = new IgracMapper();
        }

        // GET: api/igrac
        [HttpGet]
        [Route("api/igrac/allFromTeam")]
        public IQueryable<Igraci> GetIgracs(int id)
        {
            return db.Igraci.Where(x=>x.MomcadId == id);
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetIgracCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapIgracCollectionToBasicIgracCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/igrac/count")]
        public IHttpActionResult GetIgracCount()
        {
            var result = _service.GetIgracCount();
            return Ok(result);
        }

        // GET: api/igrac/5
        public IHttpActionResult GetIgrac(int id)
        {
            var result = _service.GetIgrac(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapIgracToBasicIgrac(result);
            return Ok(response);
        }

        // POST: api/igrac
        public IHttpActionResult PostIgrac([FromBody] IgracView igrac)
        {
            var model = _mapper.MapIgracViewToIgrac(igrac);
            var result = _service.AddIgrac(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/igrac/5
        public IHttpActionResult Put([FromBody] IgracView igrac)
        {
            var model = _mapper.MapIgracViewToIgrac(igrac);
            var result = _service.UpdateIgrac(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/igrac/5
        public bool Delete(int id)
        {
            try
            {
                var igrac = db.Igraci.SingleOrDefault(v => v.Id == id);
                if (igrac != null)
                {
                    db.Igraci.Remove(igrac);
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
