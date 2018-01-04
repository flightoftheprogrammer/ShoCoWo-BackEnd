﻿using System;
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

        public WalletDetail GetWallet()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetWallet(ctx);

                return
                    new WalletDetail()
                    {
                        WalletId = entity.WalletId,
                        UserId = entity.UserId,
                        WalletBalance = entity.WalletBalance,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }

        public bool UpdateWalletBalance(decimal amount)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetWallet(ctx);

                entity.WalletBalance += amount;

                return ctx.SaveChanges() == 1;
            }
        }

        private Wallet GetWallet(ApplicationDbContext context)
        {
            return
                context
                    .Wallets
                    .Single(w => w.UserId == _userId);
        }
    }
}
