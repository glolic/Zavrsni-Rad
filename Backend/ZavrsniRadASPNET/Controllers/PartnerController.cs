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
    public class PartnerController : ApiController
    {
        private IPartneriService _service;
        private PartnerMapper _mapper;
        private HokejKlubContext db = new HokejKlubContext();

        public PartnerController()
        {
            this._service = new PartnerService();
            this._mapper = new PartnerMapper();
        }

        // GET: api/partneri
        [HttpGet]
        public IQueryable<Partneri> GetPartneris()
        {
            return db.Partneri;
        }


        [HttpGet]
        public IHttpActionResult Get(string pageIndex, string pageSize, string sortColumn, string sortOrder)
        {
            var result = _service.GetPartnerCollection(Int32.Parse(pageIndex), Int32.Parse(pageSize), sortColumn, sortOrder);
            var response = _mapper.MapPartnerCollectionToBasicPartnerCollection(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/partner/count")]
        public IHttpActionResult GetPartnerCount()
        {
            var result = _service.GetPartnerCount();
            return Ok(result);
        }

        // GET: api/partneri/5
        public IHttpActionResult GetPartner(int id)
        {
            var result = _service.GetPartner(id);
            if (result == null)
            {
                return BadRequest("Not found.");
            }
            var response = _mapper.MapPartnerToBasicPartner(result);
            return Ok(response);
        }

        // POST: api/partneri
        public IHttpActionResult PostPartneri([FromBody] PartnerView partner)
        {
            var model = _mapper.MapPartnerViewToPartner(partner);
            var result = _service.AddPartner(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        // PUT: api/partneri/5
        public IHttpActionResult Put([FromBody] PartnerView partner)
        {
            var model = _mapper.MapPartnerViewToPartner(partner);
            var result = _service.UpdatePartner(model);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/partneri/5
        public bool Delete(int id)
        {
            try
            {
                var partneri = db.Partneri.SingleOrDefault(v => v.Id == id);
                if (partneri != null)
                {
                    db.Partneri.Remove(partneri);
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