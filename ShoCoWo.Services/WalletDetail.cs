using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoCoWo.Models.Wallet
{
    public class WalletDetail
    {
        public int WalletId { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public decimal WalletBalance { get; set; }
    }
}
