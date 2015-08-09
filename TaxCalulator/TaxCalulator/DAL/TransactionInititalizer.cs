using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalulator.DAL
{
    public class TransactionInititalizer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TransactinDataContext>
    {
        protected override void Seed(TransactinDataContext context)
        {
        }
    }
}