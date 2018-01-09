using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
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
    }
}
