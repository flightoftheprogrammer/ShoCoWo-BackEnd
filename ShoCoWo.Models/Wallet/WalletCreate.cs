using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoCoWo.Models.Wallet
{
    public class WalletCreate
    {
        [DefaultValue(0.00)]
        public decimal WalletBalance { get; set; }
    }
}
