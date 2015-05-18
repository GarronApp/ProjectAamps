using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class BondAtt
    {
        public BondAtt()
        {
            this.BondConditionTrs = new List<BondConditionTr>();
            this.Comments = new List<Comment>();
        }
        [DataMember]
        public int BondAttID { get; set; }
        public Nullable<System.DateTime> BondAttInstRecDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> BondAttBankRecDt { get; set; }
        [DataMember]
        public bool BondAttConditionsBt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> BondAttClientSignedDt { get; set; }
        [DataMember]
        public bool BondAttCostPaidBt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> BondAttCostPaidDt { get; set; }
        [DataMember]
        public int SaleID { get; set; }
        [DataMember]
        public System.DateTime BondAttAddedDt { get; set; }
        [DataMember]
        public System.DateTime BondAttModifiedDt { get; set; }
        [DataMember]
        public int BondAttAddedByUser { get; set; }
        [DataMember]
        public int BondAttModifiedByUser { get; set; }
        [DataMember]
        public virtual Sale Sale { get; set; }
        [DataMember]
        public virtual ICollection<BondConditionTr> BondConditionTrs { get; set; }
        [DataMember]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
