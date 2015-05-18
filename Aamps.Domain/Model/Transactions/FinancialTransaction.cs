using Aamps.Domain.Model.Sales;
using Aamps.Domain.Model.UserCompanies;
using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.Transactions
{
    public partial class FinancialTransaction
    {
        public int FinancialTrID { get; set; }
        public int FinancialTypeID { get; set; }
        public double FinancialTrAmount { get; set; }
        public System.DateTime FinancialTrDueDt { get; set; }
        public System.DateTime FinancialTrEffectiveDt { get; set; }
        public string FinancialTrComment { get; set; }
        public System.DateTime FinancialTrAddedDt { get; set; }
        public System.DateTime FinancialTrModifiedDt { get; set; }
        public int FinancialTrAddedByUser { get; set; }
        public int FinancialTrModifiedByUser { get; set; }
        public int SaleID { get; set; }
        public int TransAttID { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual FinancialType FinancialType { get; set; }
        public virtual UserList UserList { get; set; }
        public virtual TransactionAtt TransactionAtt { get; set; }
    }
}
