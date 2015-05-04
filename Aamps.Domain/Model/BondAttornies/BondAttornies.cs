using Aamps.Domain.Model.Master;
using Aamps.Domain.Model.Sales;
using Aamps.Domain.Model.Transactions;
using Aamps.Domain.Model.UserCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.BondAttornies
{
    public partial class BondAtt
    {
        public BondAtt()
        {
            this.BondConditionTransactions = new List<BondConditionTransaction>();
            this.Comments = new List<Comment>();
        }

        public int BondAttID { get; set; }
        public Nullable<System.DateTime> BondAttInstRecDt { get; set; }
        public Nullable<System.DateTime> BondAttBankRecDt { get; set; }
        public bool BondAttConditionsBt { get; set; }
        public Nullable<System.DateTime> BondAttClientSignedDt { get; set; }
        public bool BondAttCostPaidBt { get; set; }
        public Nullable<System.DateTime> BondAttCostPaidDt { get; set; }
        public int SaleID { get; set; }
        public System.DateTime BondAttAddedDt { get; set; }
        public System.DateTime BondAttModifiedDt { get; set; }
        public int BondAttAddedByUser { get; set; }
        public int BondAttModifiedByUser { get; set; }
        public virtual UserList UserList { get; set; }
        public virtual UserList UserList1 { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual ICollection<BondConditionTransaction> BondConditionTransactions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
