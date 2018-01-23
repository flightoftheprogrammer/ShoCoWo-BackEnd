using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ShoCoWo.Models.Holding;
using ShoCoWo.Services;

namespace ShoCoWo.Api.Controllers
{
    public class HoldingController : ApiController
    {
        private HoldingService CreateHoldingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HoldingService(userId);
            return service;
        }

        public IHttpActionResult Post(HoldingCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateHoldingService();

            if (!service.CreateHolding(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult GetHoldings()
        {
            var service = CreateHoldingService();
            var holdings = service.GetHoldings();

            if (!holdings.Any())
                return BadRequest();

            return Ok(holdings);
        }

        public IHttpActionResult GetHolding(int id)
        {
            var service = CreateHoldingService();
            var holding = service.GetHoldingById(id);

            return Ok(holding);
        }


        [Route("GetHoldingByCurrency")]
        public IHttpActionResult GetHoldingByCurrencyId(int currencyId)
        {
            var service = CreateHoldingService();
            var holding = service.GetHoldingByCurrencyId(currencyId);

            return Ok(holding);
        }
    }
}
