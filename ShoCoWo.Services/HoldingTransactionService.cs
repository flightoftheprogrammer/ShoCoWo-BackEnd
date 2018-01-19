using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoCoWo.Data;
using ShoCoWo.Models.HoldingTransaction;

namespace ShoCoWo.Services
{
    public class HoldingTransactionService
    {
        private readonly Guid _userId;

        public HoldingTransactionService(Guid userId)
        {
            _userId = userId;
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

        public ICollection<HoldingTransactionListItem> GetHoldingTransactions(int holdingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .HoldingTransactions
                        .Where(ht => ht.Holding.Wallet.UserId == _userId &&
                                     ht.HoldingId == holdingId)
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

        public HoldingTransactionDetail GetHoldingTransaction(int holdingTransactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HoldingTransactions
                        .Single(ht => ht.HoldingTransactionId == holdingTransactionId &&
                                      ht.Holding.Wallet.UserId == _userId);

                return
                    new HoldingTransactionDetail()
                    {
                        HoldingId = entity.HoldingId,
                        HoldingTransactionId = entity.HoldingTransactionId,
                        CryptoTransactionAmount = entity.CryptoTransactionAmount,
                        MarketValue = entity.MarketValue,
                        TransactionDate = entity.TransactionDate
                    };
            }
        }
    }
}
