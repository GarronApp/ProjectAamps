using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class Individual
    {
        public Individual()
        {
            this.PurchaserIndividualLinks = new List<PurchaserIndividualLink>();
            //this.Sales = new List<Sale>();
        }
        [DataMember]
        public int IndividualID { get; set; }
        [DataMember]
        public string IndividualName { get; set; }
        [DataMember]
        public string IndividualSurname { get; set; }
        [DataMember]
        public string IndividualIDNumber { get; set; }
        [DataMember]
        public string IndividualContactCell { get; set; }
        [DataMember]
        public string IndividualContactHome { get; set; }
        [DataMember]
        public string IndividualContactWork { get; set; }
        [DataMember]
        public string IndividualEmail { get; set; }
        [DataMember]
        public int PreferedContactMethodID { get; set; }
        [DataMember]
        public string IndividualCountryofOriginan { get; set; }
        [DataMember]
        public virtual PreferedContactMethod PreferedContactMethod { get; set; }
        [DataMember]
        public virtual ICollection<PurchaserIndividualLink> PurchaserIndividualLinks { get; set; }
        //public virtual ICollection<Sale> Sales { get; set; }
    }
}
