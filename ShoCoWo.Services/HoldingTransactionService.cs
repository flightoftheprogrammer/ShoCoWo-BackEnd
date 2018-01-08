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

        public ICollection<HoldingTransactionListItem> GetHoldingTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .HoldingTransactions
                        .Where(ht => ht.Holding.Wallet.UserId == _userId &&
                                     ht.HoldingId == _holdingId)
                        .Select(
                            e => new HoldingTransactionListItem()
                            {
                                HoldingId = e.HoldingId,
                                CryptoTransactionAmount = e.CryptoTransactionAmount,
                                MarketValue = e.MarketValue,
                                TransactionDate = e.TransactionDate,
                                HoldingTransactionId = e.HoldingTransactionId
                            });

                return query.ToList();
            }
        }
    }
}
