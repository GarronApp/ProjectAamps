using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Master
{
    public partial class PurchaserIndividualLink
    {
        public int PurchaserIndividualLinkID { get; set; }
        public int PurchaserID { get; set; }
        public int IndividualID { get; set; }
        public bool PurchaserIndividualLinkMainContact { get; set; }
        public virtual Individual Individual { get; set; }
        public virtual Purchaser Purchaser { get; set; }
    }
}
