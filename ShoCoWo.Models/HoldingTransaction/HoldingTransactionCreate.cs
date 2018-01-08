using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoCoWo.Models.HoldingTransaction
{
    public class HoldingTransactionCreate
    {
        public int HoldingId { get; set; }
        public decimal CryptoTransactionAmount { get; set; }
        public decimal MarketValue { get; set; }
    }
}
