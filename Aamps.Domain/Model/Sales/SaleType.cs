using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Sales
{
    public partial class SaleType
    {
        public SaleType()
        {
            this.Sales = new List<Sale>();
        }

        public int SaleTypeID { get; set; }
        public string SaleTypeDescription { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
