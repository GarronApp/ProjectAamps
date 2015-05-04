using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.Transactions
{
    public partial class CommissionType
    {
        public CommissionType()
        {
            this.CommissionTransactions = new List<CommissionTransaction>();
        }

        public int CommissionTypeID { get; set; }
        public string CommissionTypeDescription { get; set; }
        public virtual ICollection<CommissionTransaction> CommissionTransactions { get; set; }
    }
}
