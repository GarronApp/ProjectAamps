using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Sales
{
    public partial class SaleStatus
    {
        public SaleStatus()
        {
            this.Sales = new List<Sale>();
        }

        public int SaleStatusID { get; set; }
        public string SaleStatusDescription { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
