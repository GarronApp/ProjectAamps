using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AAMPS.Domain.ViewModels.Bonds
{
    public partial class OrginatorViewModel
    {
        [DataMember]
        public int OriginatorTrID { get; set; }
        [DataMember]
        public int CurrentOriginatorTrID { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string MOStatus { get; set; }
        [DataMember]
        public string OriginatorTrSubmittedDt { get; set; }
        [DataMember]
        public string OriginatorTrAIPDt { get; set; }
        [DataMember]
        public string OriginatorTrGrantDt { get; set; }
        [DataMember]
        public int OriginatorTrAcceptedBt { get; set; }
        [DataMember]
        public string OriginatorTrAcceptDt { get; set; }
        [DataMember]
        public double OriginatorTrBondAmount { get; set; }
        [DataMember]
        public double OriginatorTrIntRate { get; set; }
        [DataMember]
        public string OriginatorTrAddedDt { get; set; }
        [DataMember]
        public string OriginatorTrModifiedDt { get; set; }
        [DataMember]
        public int SaleID { get; set; }
    }
}