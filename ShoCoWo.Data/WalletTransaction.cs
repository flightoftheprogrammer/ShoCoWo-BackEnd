using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoCoWo.Data
{
    public class WalletTransaction
    {
        [Key]
        public int WalletTransactionId { get; set; }

        [Required]
        public int WalletId { get; set; }

        [Required]
        public decimal TransactionAmount { get; set; }

        [Required]
        public DateTimeOffset TransactionDate { get; set; }

        public virtual Wallet Wallet { get; set; }
    }
}
