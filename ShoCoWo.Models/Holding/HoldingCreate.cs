﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoCoWo.Models.Holding
{
    public class HoldingCreate
    {
        public int WalletId { get; set; }
        public decimal CryptoHoldingBalance { get; set; }
        public int CurrencyId { get; set; }
        public decimal MarketValueTotal { get; set; }
    }
}
