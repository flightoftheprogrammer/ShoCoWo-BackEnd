using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoCoWo.Data;
using ShoCoWo.Models.Holding;

namespace ShoCoWo.Services
{
    public class HoldingService
    {
        private readonly Guid _userId;
        private readonly int _walletId;
        private readonly WalletService _walletService;

        public HoldingService(Guid userId)
        {
            _userId = userId;
            _walletService = new WalletService(userId);
            _walletId = _walletService.GetWalletId();
        }

        public bool CreateHolding(HoldingCreate model)
        {
            var entity =
                new Holding()
                {
                    WalletId = model.WalletId,
                    CryptoHoldingBalance = model.CryptoHoldingBalance,
                    CurrencyId = model.CurrencyId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Holdings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<HoldingListItem> GetHoldings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var wallet =
                    ctx
                        .Wallets
                        .SingleOrDefault(w => w.WalletId == _walletId);

                var query =
                    ctx
                        .Holdings
                        .Where(h => h.WalletId == _walletId)
                        .Select(
                            e => new HoldingListItem()
                            {
                                HoldingId = e.HoldingId,
                                CryptoHoldingBalance = e.CryptoHoldingBalance,
                                CurrencyId = e.CurrencyId,
                            }
                        );

                return query.ToList();
            }
        }

        public HoldingDetail GetHoldingById(int holdingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetHoldingById(ctx, holdingId);

                return
                    new HoldingDetail()
                    {
                        HoldingId = entity.HoldingId,
                        CryptoHoldingBalance = entity.CryptoHoldingBalance,
                        CurrencyId = entity.CurrencyId,
                        WalletId = entity.WalletId
                    };
            }
        }

        public bool UpdateHoldingBalance(int holdingId, decimal amount)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetHoldingById(ctx, holdingId);

                entity.CryptoHoldingBalance += amount;

                return ctx.SaveChanges() == 1;
            }
        }

        private Holding GetHoldingById(ApplicationDbContext context, int holdingId)
        {
            return
                context
                    .Holdings
                    .Single(h => h.HoldingId == holdingId &&
                                 h.Wallet.UserId == _userId);
        }
    }
}
