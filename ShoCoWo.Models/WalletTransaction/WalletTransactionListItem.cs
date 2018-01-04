﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoCoWo.Models.WalletTransaction
{
    public class WalletTransactionListItem
    {
        public int WalletTransactionId { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
    }
}
