using Aamps.Domain.Model.BondAttornies;
using Aamps.Domain.Model.Master;
using Aamps.Domain.Model.Transactions;
using Aamps.Domain.Model.Units;
using Aamps.Domain.Model.UserCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Sales
{
    public partial class Sale
    {
        public Sale()
        {
            this.BondAtts = new List<BondAtt>();
            this.Comments = new List<Comment>();
            this.BondConditionTransactions = new List<BondConditionTransaction>();
            this.CommissionTransactions = new List<CommissionTransaction>();
            this.FinancialTransactions = new List<FinancialTransaction>();
            this.OriginatorTransactions = new List<OriginatorTransaction>();
            this.TransactionAtts = new List<TransactionAtt>();
        }

        public int SaleID { get; set; }
        public int UnitID { get; set; }
        public int SaleTypeID { get; set; }
        public int SaleStatusID { get; set; }
        public Nullable<int> SaleActiveStatusID { get; set; }
        public System.DateTime SaleAddedDt { get; set; }
        public System.DateTime SaleModifiedDt { get; set; }
        public int SaleAddedByUser { get; set; }
        public int SaleModifiedByUser { get; set; }
        public Nullable<System.DateTime> SaleReservationDt { get; set; }
        public Nullable<System.DateTime> SaleReservationExpiryDt { get; set; }
        public Nullable<System.DateTime> SaleReservationExtentionDt { get; set; }
        public Nullable<System.DateTime> SaleContractSignedPurchaserDt { get; set; }
        public Nullable<System.DateTime> SaleContractSignedSellerDt { get; set; }
        public bool SaleDepositPaidBt { get; set; }
        public bool SalesBondRequiredBt { get; set; }
        public double SaleBondRequiredAmount { get; set; }
        public Nullable<System.DateTime> SaleBondDueTimeDt { get; set; }
        public Nullable<System.DateTime> SaleBondDueExpiryDt { get; set; }
        public bool SalesReferalCommDueBt { get; set; }
        public Nullable<int> MortgageOriginatorID { get; set; }
        public Nullable<int> BankID { get; set; }
        public string SalesBondAccountNo { get; set; }
        public Nullable<double> SalesBondInterestRate { get; set; }
        public Nullable<double> SalesBondAmount { get; set; }
        public Nullable<System.DateTime> SalesBondGrantedDt { get; set; }
        public Nullable<System.DateTime> SalesBondClientAcceptDt { get; set; }
        public bool SalesBondCommDueBt { get; set; }
        public Nullable<int> SalesTransferAttAssignedID { get; set; }
        public Nullable<int> SalesBondAttAssignedID { get; set; }
        public virtual ICollection<BondAtt> BondAtts { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<BondConditionTransaction> BondConditionTransactions { get; set; }
        public virtual ICollection<CommissionTransaction> CommissionTransactions { get; set; }
        public virtual ICollection<FinancialTransaction> FinancialTransactions { get; set; }
        public virtual ICollection<OriginatorTransaction> OriginatorTransactions { get; set; }
        public virtual Company Company { get; set; }
        public virtual SaleActiveStatus SaleActiveStatus { get; set; }
        public virtual UserList UserList { get; set; }
        public virtual SaleStatus SaleStatus { get; set; }
        public virtual SaleType SaleType { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<TransactionAtt> TransactionAtts { get; set; }
    }
}
