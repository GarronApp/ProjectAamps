using Aamps.Domain.Model.BondAttornies;
using Aamps.Domain.Model.Sales;
using Aamps.Domain.Model.UserCompanies;
using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.Transactions
{
    public partial class BondConditionTransaction
    {
        public int BondConditionTrID { get; set; }
        public int BondConditionDescription { get; set; }
        public System.DateTime BondConditionTrAddedDt { get; set; }
        public System.DateTime BondConditionTrModifiedDt { get; set; }
        public int BondConditionTrAddedByUser { get; set; }
        public int BondConditionTrModifiedByUser { get; set; }
        public int SaleID { get; set; }
        public int BondAttID { get; set; }
        public virtual BondAtt BondAtt { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual UserList UserList { get; set; }

    }
}
