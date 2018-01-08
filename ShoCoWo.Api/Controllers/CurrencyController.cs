using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoCoWo.Models.Currency;
using ShoCoWo.Services;

namespace ShoCoWo.Api.Controllers
{
    public class CurrencyController : ApiController
    {
        public IHttpActionResult Post(CurrencyCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new CurrencyService();

            if (!service.CreateCurrency(model))
                return InternalServerError();

            return Ok();
        }
    }
}
