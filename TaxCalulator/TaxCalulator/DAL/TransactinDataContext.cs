using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaxCalulator.Models;

namespace TaxCalulator.DAL
{
    public class TransactinDataContext :DbContext
    {
        public TransactinDataContext()
            :base("TransactionData")
        {

        }
        public DbSet<TransactionData> TransactionsData { get; set; }
    }
}