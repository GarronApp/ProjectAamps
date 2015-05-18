using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class OriginatorTr
    {
        [DataMember]
        public int OriginatorTrID { get; set; }
        [DataMember]
        public int MOStatusID { get; set; }
        [DataMember]
        public int BankID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> OriginatorTrSubmittedDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> OriginatorTrAIPDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> OriginatorTrGrantDt { get; set; }
        [DataMember]
        public bool OriginatorTrAcceptedBt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> OriginatorTrAcceptDt { get; set; }
        [DataMember]
        public double OriginatorTrBondAmount { get; set; }
        [DataMember]
        public double OriginatorTrIntRate { get; set; }
        [DataMember]
        public System.DateTime OriginatorTrAddedDt { get; set; }
        [DataMember]
        public System.DateTime OriginatorTrModifiedDt { get; set; }
        [DataMember]
        public int OriginatorTrAddedByUser { get; set; }
        [DataMember]
        public int OriginatorTrModifiedByUser { get; set; }
        [DataMember]
        public int SaleID { get; set; }
        [DataMember]
        public virtual Bank Bank { get; set; }
        [DataMember]
        public virtual Sale Sale { get; set; }
        [DataMember]
        public virtual MOStatus MOStatu { get; set; }
    }
}
