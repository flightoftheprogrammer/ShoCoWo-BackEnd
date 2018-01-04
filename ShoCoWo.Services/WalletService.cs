using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoCoWo.Data;
using ShoCoWo.Models.Wallet;

namespace ShoCoWo.Services
{
    public class WalletService
    {
        private readonly Guid _userId;

        public WalletService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWallet(WalletCreate model)
        {
            var entity =
                new Wallet()
                {
                    UserId = _userId,
                    WalletBalance = model.WalletBalance,
                    CreatedUtc = DateTimeOffset.UtcNow
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Wallets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
