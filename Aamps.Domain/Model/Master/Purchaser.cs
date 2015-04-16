using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Master
{
    public partial class Purchaser
    {
        public Purchaser()
        {
            this.PurchaserIndividualLinks = new List<PurchaserIndividualLink>();
        }

        public int PurchaserID { get; set; }
        public int EntityTypeID { get; set; }
        public string PurchaserDescription { get; set; }
        public string PurchaserRegID { get; set; }
        public string PurchaserContactPerson { get; set; }
        public string PurchaserContactCell { get; set; }
        public string PurchaserContactHome { get; set; }
        public string PurchaserContactWork { get; set; }
        public string PurchaserEmail { get; set; }
        public string PurchaserAddress { get; set; }
        public string PurchaserAddress1 { get; set; }
        public string PurchaserAddress2 { get; set; }
        public string PurchaserAddress3 { get; set; }
        public string PurchaserPostalCode { get; set; }
        public string PurchaserSuburb { get; set; }
        public virtual EntityType EntityType { get; set; }
        public virtual ICollection<PurchaserIndividualLink> PurchaserIndividualLinks { get; set; }
    }
}
