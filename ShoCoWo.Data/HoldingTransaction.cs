using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoCoWo.Data
{
    public class HoldingTransaction
    {
        [Key]
        public int HoldingTransactionId { get; set; }

        [Required]
        public int HoldingId { get; set; }

        [Required]
        public decimal CryptoTransactionAmount { get; set; }

        [Required]
        public DateTimeOffset TransactionDate { get; set; }

        [Required]
        public decimal MarketValue { get; set; }

        public virtual Holding Holding { get; set; }
    }
}
