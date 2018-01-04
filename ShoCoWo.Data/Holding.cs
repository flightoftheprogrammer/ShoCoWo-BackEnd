using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoCoWo.Data
{
    public class Holding
    {
        [Key]
        public int HoldingId { get; set; }

        [Required]
        public int WalletId { get; set; }

        public decimal CryptoHoldingBalance { get; set; }

        public int CurrencyId { get; set; }

        public decimal MarketValueTotal { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual ICollection<HoldingTransaction> HoldingTransactions { get; set; }
    }
}
