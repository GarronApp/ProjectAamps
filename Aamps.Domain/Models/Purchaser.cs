using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class Purchaser
    {
        public Purchaser()
        {
            this.PurchaserIndividualLinks = new List<PurchaserIndividualLink>();
            //this.Sales = new List<Sale>();
        }
        [DataMember]
        public int PurchaserID { get; set; }
        [DataMember]
        public int EntityTypeID { get; set; }
        [DataMember]
        public string PurchaserDescription { get; set; }
        [DataMember]
        public string PurchaserRegID { get; set; }
        [DataMember]
        public string PurchaserContactPerson { get; set; }
        [DataMember]
        public string PurchaserContactCell { get; set; }
        [DataMember]
        public string PurchaserContactHome { get; set; }
        [DataMember]
        public string PurchaserContactWork { get; set; }
        [DataMember]
        public string PurchaserEmail { get; set; }
        [DataMember]
        public string PurchaserAddress { get; set; }
        [DataMember]
        public string PurchaserAddress1 { get; set; }
        [DataMember]
        public string PurchaserAddress2 { get; set; }
        [DataMember]
        public string PurchaserAddress3 { get; set; }
        [DataMember]
        public string PurchaserPostalCode { get; set; }
        [DataMember]
        public string PurchaserSuburb { get; set; }
        [DataMember]
        public Nullable<int> PurchaserCoAddedID { get; set; }
        [DataMember]
        public Nullable<int> PurchaserUserAddedID { get; set; }
        [DataMember]
        public virtual EntityType EntityType { get; set; }
        [DataMember]
        public virtual ICollection<PurchaserIndividualLink> PurchaserIndividualLinks { get; set; }
        //[DataMember]
        //public virtual ICollection<Sale> Sales { get; set; }

    }
}
