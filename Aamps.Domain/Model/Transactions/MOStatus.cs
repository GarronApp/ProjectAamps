using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.Transactions
{
    public partial class MOStatus
    {
        public MOStatus()
        {
            this.OriginatoTransactions = new List<OriginatorTransaction>();
        }

        public int MOStatusID { get; set; }
        public string MOStatusDescription { get; set; }
        public virtual ICollection<OriginatorTransaction> OriginatoTransactions { get; set; }
    }
}
