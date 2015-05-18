using Aamps.Domain.Model.BondAttornies;
using Aamps.Domain.Model.Master;
using Aamps.Domain.Model.Sales;
using Aamps.Domain.Model.Transactions;
using Aamps.Domain.Model.Units;
using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.UserCompanies
{
    public partial class UserList
    {
        public UserList()
        {
            this.BondAtts = new List<BondAtt>();
            this.Comments = new List<Comment>();
            this.Sales = new List<Sale>();
            this.BondConditionTransactions = new List<BondConditionTransaction>();
            this.CommissionTransactionans = new List<CommissionTransaction>();
            this.FinancialTransactions = new List<FinancialTransaction>();
            this.OriginatorTransactions = new List<OriginatorTransaction>();
            this.TransactionAtts = new List<TransactionAtt>();
            this.Units = new List<Unit>();
            //this.UserLists = new List<UserList>();
            this.UserRights = new List<UserRight>();
        }

        public int UserListID { get; set; }
        public string UserListName { get; set; }
        public string UserListSurname { get; set; }
        public string UserListPassword { get; set; }
        public string UserListEmail { get; set; }
        public int UserTypeID { get; set; }
        public int CompanyID { get; set; }
        public int UserGroupID { get; set; }
        public int UserListAddedby { get; set; }
        public int UserListLastModifiedby { get; set; }
        public System.DateTime UserListDateAdded { get; set; }
        public System.DateTime UserListDateModified { get; set; }
        public bool UserListInActive { get; set; }
        public virtual ICollection<BondAtt> BondAtts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<BondConditionTransaction> BondConditionTransactions { get; set; }
        public virtual ICollection<CommissionTransaction> CommissionTransactionans { get; set; }
        public virtual ICollection<FinancialTransaction> FinancialTransactions { get; set; }
        public virtual ICollection<OriginatorTransaction> OriginatorTransactions { get; set; }
        public virtual ICollection<TransactionAtt> TransactionAtts { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
        public virtual Company Company { get; set; }
        public virtual UserGroup UserGroup { get; set; }
        //public virtual ICollection<UserList> UserLists { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<UserRight> UserRights { get; set; }
    }
}
