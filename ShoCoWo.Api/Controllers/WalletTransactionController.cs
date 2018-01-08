﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ShoCoWo.Models.WalletTransaction;
using ShoCoWo.Services;

namespace ShoCoWo.Api.Controllers
{
    public class WalletTransactionController : ApiController
    {
        private WalletTransactionService CreateWalletTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var walletService = new WalletService(userId);
            var service = new WalletTransactionService(userId, walletService.GetWalletId());
            return service;
        }

        //POST /api/wallettransaction 
        public IHttpActionResult Post(WalletTransactionCreate walletTransaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateWalletTransactionService();

            if (!service.CreateWalletTransaction(walletTransaction))
                return InternalServerError();

            return Ok();
        }

    }
}
