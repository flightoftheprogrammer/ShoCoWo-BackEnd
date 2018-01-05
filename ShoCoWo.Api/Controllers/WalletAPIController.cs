using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ShoCoWo.Models.Wallet;
using ShoCoWo.Services;

namespace ShoCoWo.Api.Controllers
{
    public class WalletAPIController : ApiController
    {

        private WalletService CreateWalletService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var walletService = new WalletService(userId);
            return walletService;

        }
        
        //Get api/wallet
        public IHttpActionResult GetWallet()
        {
            WalletService walletService = CreateWalletService();
            var wallets = walletService.GetWallet();

            return Ok(wallets);

        }

        //POST /api/wallet
        public IHttpActionResult Post(WalletCreate wallet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateWalletService();

            if (!service.CreateWallet(wallet))
                return InternalServerError();

            return Ok();
        }
        //PUT /api/wallet
        public IHttpActionResult Put(decimal amount)
        {
            if (!ModelState.IsValid)
                return BadRequest((ModelState));

            var service = CreateWalletService();

            if (!service.UpdateWalletBalance(amount))
                return InternalServerError();

            return Ok();
        }
    }
}
