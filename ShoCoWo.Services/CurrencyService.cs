using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoCoWo.Data;
using ShoCoWo.Models.Currency;

namespace ShoCoWo.Services
{
    public class CurrencyService
    {
        public bool CreateCurrency(CurrencyCreate model)
        {
            var entity = 
                new Currency()
                {
                    CurrencyName = model.CurrencyName,
                    CurrencyNameLong = model.CurrencyNameLong
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx
                    .Currencies
                    .Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<CurrencyListItem> GetCurrencies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Currencies
                        .Select(
                            c => new CurrencyListItem()
                            {
                                CurrencyId = c.CurrencyId,
                                CurrencyName = c.CurrencyName,
                                CurrencyNameLong = c.CurrencyNameLong
                            }
                        );

                return query.ToList();
            }
        }

        public CurrencyDetail GetCurrency(int currencyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Currencies
                        .Single(c => c.CurrencyId == currencyId);

                return
                    new CurrencyDetail()
                    {
                        CurrencyId = entity.CurrencyId,
                        CurrencyName = entity.CurrencyName,
                        CurrencyNameLong = entity.CurrencyNameLong
                    };
            }
        }

        public bool EditCurrency(CurrencyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetCurrency(model.CurrencyId);

                entity.CurrencyName = model.CurrencyName;
                entity.CurrencyNameLong = model.CurrencyNameLong;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
