using Aamps.Domain.Model.BondAttornies;
using Aamps.Domain.Model.Sales;
using Aamps.Domain.Model.Transactions;
using Aamps.Domain.Model.UserCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Master
{
    public partial class Comment
    {
        public int CommentID { get; set; }
        public string CommentDetails { get; set; }
        public System.DateTime CommentAddedDt { get; set; }
        public int CommentAddedByUser { get; set; }
        public int CommentGroupID { get; set; }
        public int SaleID { get; set; }
        public Nullable<int> BondAttID { get; set; }
        public Nullable<int> TransAttID { get; set; }
        public virtual BondAtt BondAtt { get; set; }
        public virtual UserList UserList { get; set; }
        public virtual CommentGroup CommentGroup { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual TransactionAtt TransactionAtt { get; set; }
    }
}
