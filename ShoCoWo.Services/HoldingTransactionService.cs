using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoCoWo.Data;
using ShoCoWo.Models.HoldingTransaction;

namespace ShoCoWo.Services
{
    class HoldingTransactionService
    {
        private readonly Guid _userId;
        private readonly int _holdingId;

        public HoldingTransactionService(Guid userId, int holdingId)
        {
            _userId = userId;
            _holdingId = holdingId;
        }

        public bool CreateHoldingTransaction(HoldingTransactionCreate model)
        {
            var entity =
                new HoldingTransaction()
                {
                    HoldingId = model.HoldingId,
                    CryptoTransactionAmount = model.CryptoTransactionAmount,
                    MarketValue = model.MarketValue,
                    TransactionDate = DateTimeOffset.UtcNow
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.HoldingTransactions.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
