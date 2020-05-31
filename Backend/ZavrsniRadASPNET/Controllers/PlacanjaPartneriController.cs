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
    public class PlacanjaPartneriController : ApiController
    {
        private IPlacanjaPartneraService _service;
        private PlacanjaPartneriMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public PlacanjaPartneriController()
        {
            this._service = new PlacanjaPartneraService();
            this._mapper = new PlacanjaPartneriMapper();
        }

        // GET: api/placanjaPartneri
        [HttpGet]
        public IQueryable<PlacanjaPartneri> GetPlacanjaPartneris()
        {
            return db.PlacanjaPartneri;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetPlacanjaPartneraCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapPlacanjaPartneriCollectionToBasicPlacanjaPartneriCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/PlacanjaPartneri/count")]
        public IHttpActionResult GetPlacanjaPartneriCount()
        {
            var result = _service.GetPlacanjaPartneriCount();
            return Ok(result);
        }

        // GET: api/placanjaPartneri/5
        public IHttpActionResult GetPlacanjaPartneri(int id)
        {
            var result = _service.GetPlacanjaPartner(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapPlacanjaPartneriToBasicPlacanjaPartneri(result);
            return Ok(response);
        }

        // POST: api/placanjaPartneri
        public IHttpActionResult PostPlacanjaPartneri([FromBody] PlacanjaPartneraView placanjaPartneri)
        {
            var model = _mapper.MapPlacanjaPartneraViewToPlacanjaPartneri(placanjaPartneri);
            var result = _service.AddPlacanjaPartner(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/placanjaPartneri/5
        public IHttpActionResult Put([FromBody] PlacanjaPartneraView placanjaPartneri)
        {
            var model = _mapper.MapPlacanjaPartneraViewToPlacanjaPartneri(placanjaPartneri);
            var result = _service.UpdatePlacanjaPartnera(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/placanjaPartneri/5
        public bool Delete(int id)
        {
            try
            {
                var placanjaPartneri = db.PlacanjaPartneri.SingleOrDefault(v => v.Id == id);
                if (placanjaPartneri != null)
                {
                    db.PlacanjaPartneri.Remove(placanjaPartneri);
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
