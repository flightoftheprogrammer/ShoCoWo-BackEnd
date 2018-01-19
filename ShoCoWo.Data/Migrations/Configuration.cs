using System.Collections.Generic;

namespace ShoCoWo.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShoCoWo.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShoCoWo.Data.ApplicationDbContext context)
        {
            var currencies = new List<Currency>
            {
                new Currency() {CurrencyId = 1, CurrencyNameLong = "Bitcoin", CurrencyName = "BTC"},
                new Currency() {CurrencyId = 2, CurrencyName = "ETH", CurrencyNameLong = "Ethereum"}
            };

            context.Currencies.AddRange(currencies);

        }
    }
}
