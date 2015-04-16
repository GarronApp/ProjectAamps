using Aamps.Domain.Model.Master;
using Aamps.Domain.Model.Sales;
using Aamps.Domain.Model.UserCompanies;
using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.Transactions
{
    public partial class TransactionAtt
    {
        public TransactionAtt()
        {
            this.Comments = new List<Comment>();
            this.FinancialTransactions = new List<FinancialTransaction>();
        }

        public int TransAttID { get; set; }
        public Nullable<System.DateTime> TransAttInstRecDt { get; set; }
        public Nullable<System.DateTime> TransAttDocsDraftedDt { get; set; }
        public Nullable<System.DateTime> TransAttSellerSignedDt { get; set; }
        public Nullable<System.DateTime> TransAttPurchaserSignedDt { get; set; }
        public bool TransAttCostsPaidBt { get; set; }
        public Nullable<System.DateTime> TransAttCostsPaidDt { get; set; }
        public Nullable<System.DateTime> TransAttTDRecDt { get; set; }
        public Nullable<System.DateTime> TransAttRatesClearanceRecDt { get; set; }
        public Nullable<System.DateTime> TransAttLodgedDt { get; set; }
        public Nullable<System.DateTime> TransAttRegisteredDt { get; set; }
        public Nullable<System.DateTime> TransAttAgencyCommPaidDt { get; set; }
        public Nullable<System.DateTime> TransAttReferalCommPaidDt { get; set; }
        public Nullable<System.DateTime> TransAttAAMPSCommPaidDt { get; set; }
        public int SaleID { get; set; }
        public System.DateTime TransAttAddedDt { get; set; }
        public System.DateTime TransAttModifiedDt { get; set; }
        public int TransAttAddedByUser { get; set; }
        public int TransAttModifiedByUser { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FinancialTransaction> FinancialTransactions { get; set; }
        public virtual UserList UserList { get; set; }

    }
}
