using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaxCalulator.Models
{
    public class TransactionData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}