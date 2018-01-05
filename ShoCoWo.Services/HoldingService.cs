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
                    CurrencyId = model.CurrencyId,
                    MarketValueTotal = model.MarketValueTotal
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Holdings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
