using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoCoWo.Data
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [DefaultValue(0.00)]
        public decimal WalletBalance { get; set; }

        public virtual ICollection<WalletTransaction> WalletTransactions { get; set; }
        public virtual ICollection<Holding> Holdings { get; set; }
    }
}
