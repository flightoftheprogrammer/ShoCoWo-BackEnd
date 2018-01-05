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
    }
}
