using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ShoCoWo.Data;
using ShoCoWo.Models.HoldingTransaction;
using ShoCoWo.Models.WalletTransaction;
using ShoCoWo.Services;

namespace ShoCoWo.Api.Controllers
{
    public class HoldingTransactionController : ApiController
    {
        private HoldingTransactionService CreateHoldingTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HoldingTransactionService(userId);
            return service;
        }

        public IHttpActionResult Post(HoldingTransactionCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = Guid.Parse(User.Identity.GetUserId());

            var holdingservice = new HoldingService(userId);
            var walletService = new WalletService(userId);
            var service = CreateHoldingTransactionService();

            var usdValue = model.CryptoTransactionAmount * model.MarketValue;

            if (walletService.GetWallet().WalletBalance - usdValue < 0)
                return BadRequest();

            if (!service.CreateHoldingTransaction(model))
                return InternalServerError();

            walletService.UpdateWalletBalance(-usdValue);

            holdingservice.UpdateHoldingBalance(model.HoldingId, model.CryptoTransactionAmount);

            return Ok();
        }

        public IHttpActionResult GetHoldingTransactions(int id)
        {
            var service = CreateHoldingTransactionService();
            var transactions = service.GetHoldingTransactions(id);

            return Ok(transactions);
        }

        public IHttpActionResult GetHoldingTransaction(int transactionId)
        {
            var service = CreateHoldingTransactionService();
            var transaction = service.GetHoldingTransaction(transactionId);

            return Ok(transaction);
        }
    }
}
