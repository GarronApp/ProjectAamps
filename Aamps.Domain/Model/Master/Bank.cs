using Aamps.Domain.Model.Sales;
using Aamps.Domain.Model.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Master
{
    public partial class Bank
    {
        public Bank()
        {
            this.OriginatorTransactions = new List<OriginatorTransaction>();
            this.Sales = new List<Sale>();
        }

        public int BankID { get; set; }
        public string BankDescription { get; set; }
        public virtual ICollection<OriginatorTransaction> OriginatorTransactions { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
