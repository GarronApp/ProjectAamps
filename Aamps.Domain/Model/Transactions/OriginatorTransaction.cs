using Aamps.Domain.Model.Master;
using Aamps.Domain.Model.Sales;
using Aamps.Domain.Model.UserCompanies;
using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.Transactions
{
    public partial class OriginatorTransaction
    {
        public int OriginatorTrID { get; set; }
        public int MOStatusID { get; set; }
        public int BankID { get; set; }
        public Nullable<System.DateTime> OriginatorTrSubmittedDt { get; set; }
        public Nullable<System.DateTime> OriginatorTrAIPDt { get; set; }
        public Nullable<System.DateTime> OriginatorTrGrantDt { get; set; }
        public bool OriginatorTrAcceptedBt { get; set; }
        public Nullable<System.DateTime> OriginatorTrAcceptDt { get; set; }
        public double OriginatorTrBondAmount { get; set; }
        public double OriginatorTrIntRate { get; set; }
        public System.DateTime OriginatorTrAddedDt { get; set; }
        public System.DateTime OriginatorTrModifiedDt { get; set; }
        public int OriginatorTrAddedByUser { get; set; }
        public int OriginatorTrModifiedByUser { get; set; }
        public int SaleID { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual MOStatus MOStatus { get; set; }
        public virtual UserList UserList { get; set; }

    }
}
