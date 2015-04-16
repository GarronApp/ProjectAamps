using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class TransAtt
    {
        public TransAtt()
        {
            this.Comments = new List<Comment>();
            this.FinancialTrs = new List<FinancialTr>();
        }
        [DataMember]
        public int TransAttID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttInstRecDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttDocsDraftedDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttSellerSignedDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttPurchaserSignedDt { get; set; }
        [DataMember]
        public bool TransAttCostsPaidBt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttCostsPaidDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttTDRecDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttRatesClearanceRecDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttLodgedDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttRegisteredDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttAgencyCommPaidDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttReferalCommPaidDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransAttAAMPSCommPaidDt { get; set; }
        [DataMember]
        public int SaleID { get; set; }
        [DataMember]
        public System.DateTime TransAttAddedDt { get; set; }
        [DataMember]
        public System.DateTime TransAttModifiedDt { get; set; }
        [DataMember]
        public int TransAttAddedByUser { get; set; }
        [DataMember]
        public int TransAttModifiedByUser { get; set; }
        [DataMember]
        public virtual ICollection<Comment> Comments { get; set; }
        [DataMember]
        public virtual Sale Sale { get; set; }
        [DataMember]
        public virtual ICollection<FinancialTr> FinancialTrs { get; set; }
    }
    
}
