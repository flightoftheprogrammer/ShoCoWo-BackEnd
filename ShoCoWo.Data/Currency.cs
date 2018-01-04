using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoCoWo.Data
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }

        [Required]
        [MaxLength(3)]
        public string CurrencyName { get; set; }

        [Required]
        [MaxLength(20)]
        public string CurrencyNameLong { get; set; }
    }
}
