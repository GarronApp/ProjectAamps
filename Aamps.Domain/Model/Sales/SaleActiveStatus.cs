using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Sales
{
    public partial class SaleActiveStatus
    {
        public SaleActiveStatus()
        {
            this.Sales = new List<Sale>();
        }

        public int SaleActiveStatusID { get; set; }
        public string SaleActiveStatusDescription { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
