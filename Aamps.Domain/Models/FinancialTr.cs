using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class FinancialTr
    {
        [DataMember]
        public int FinancialTrID { get; set; }
        [DataMember]
        public int FinancialTypeID { get; set; }
        [DataMember]
        public double FinancialTrAmount { get; set; }
        [DataMember]
        public System.DateTime FinancialTrDueDt { get; set; }
        [DataMember]
        public System.DateTime FinancialTrEffectiveDt { get; set; }
        [DataMember]
        public string FinancialTrComment { get; set; }
        [DataMember]
        public System.DateTime FinancialTrAddedDt { get; set; }
        [DataMember]
        public System.DateTime FinancialTrModifiedDt { get; set; }
        [DataMember]
        public int FinancialTrAddedByUser { get; set; }
        [DataMember]
        public int FinancialTrModifiedByUser { get; set; }
        [DataMember]
        public int SaleID { get; set; }
        [DataMember]
        public int TransAttID { get; set; }
        [DataMember]
        public virtual Sale Sale { get; set; }
        [DataMember]
        public virtual FinancialType FinancialType { get; set; }
        [DataMember]
        public virtual TransAtt TransAtt { get; set; }
    }
}
