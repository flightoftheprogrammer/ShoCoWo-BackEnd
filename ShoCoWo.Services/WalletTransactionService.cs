using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoCoWo.Data;
using ShoCoWo.Models.WalletTransaction;

namespace ShoCoWo.Services
{
    public class WalletTransactionService
    {
        private readonly Guid _userId;
        private readonly int _walletId;

        public WalletTransactionService(Guid userId, int walletId)
        {
            _userId = userId;
            _walletId = walletId;
        }

        public bool CreateWalletTransaction(CreateWalletTransaction model)
        {
            var entity =
                new WalletTransaction()
                {
                    TransactionAmount = model.TransactionAmount,
                    WalletId = _walletId,
                    TransactionDate = DateTimeOffset.UtcNow
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.WalletTransactions.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<WalletTransactionListItem> GetWalletTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .WalletTransactions
                        .Where(w => w.WalletId == _walletId)
                        .Select(
                            w =>
                                new WalletTransactionListItem()
                                {
                                    WalletTransactionId = w.WalletTransactionId,
                                    TransactionAmount = w.TransactionAmount,
                                    TransactionDate = w.TransactionDate
                                }
                            );

                return query.ToList();
            }
        }

        public WalletTransactionDetail GetWalletTransactionById(int walletTransactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WalletTransactions
                        .Single(wt => wt.WalletTransactionId == walletTransactionId &&
                                      wt.Wallet.UserId == _userId);

                return
                    new WalletTransactionDetail()
                    {
                        WalletId = entity.WalletId,
                        WalletTransactionId = entity.WalletTransactionId,
                        TransactionAmount = entity.TransactionAmount,
                        TransactionDate = entity.TransactionDate
                    };
            }
        }
    }
}
