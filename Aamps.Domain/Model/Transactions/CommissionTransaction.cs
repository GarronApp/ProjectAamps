using Aamps.Domain.Model.Sales;
using Aamps.Domain.Model.UserCompanies;
using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.Transactions
{
    public partial class CommissionTransaction
    {
        public int CommissionTrID { get; set; }
        public int CommissionTypeID { get; set; }
        public int UserListID { get; set; }
        public double CommissionTrBondAmount { get; set; }
        public double CommissionTrRate { get; set; }
        public System.DateTime CommissionTrAddedDt { get; set; }
        public System.DateTime CommissionTrModifiedDt { get; set; }
        public int CommissionTrAddedByUser { get; set; }
        public int CommissionTrModifiedByUser { get; set; }
        public int SaleID { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual CommissionType CommissionType { get; set; }
        public virtual UserList UserList { get; set; }

    }
}
