using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.Transactions
{
    public partial class FinancialType
    {
        public FinancialType()
        {
            this.FinancialTransactions = new List<FinancialTransaction>();
        }

        public int FinancialTypeID { get; set; }
        public string FinancialTypeDescription { get; set; }
        public virtual ICollection<FinancialTransaction> FinancialTransactions { get; set; }
    }
}
