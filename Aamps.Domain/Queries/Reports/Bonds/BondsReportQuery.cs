using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Queries.Reports.Bonds
{
    public class BondsReportQuery
    {
        [DataMember]
        public string Development { get; set; }
        [DataMember]
        public string UnitNo { get; set; }
        [DataMember]
        public string Agency { get; set; }
        [DataMember]
        public string Agent { get; set; }
        [DataMember]
        public string Purchaser { get; set; }
        [DataMember]
        public double? Deposit { get; set; }
        [DataMember]
        public Nullable<DateTime> InstToMODt { get; set; }
        [DataMember]
        public Nullable<DateTime> BondDueDate { get; set; }
        [DataMember]
        public double? BondReq { get; set; }
        [DataMember]
        public double? BondAmountGrant { get; set; }
        [DataMember]
        public double? BondShortFall { get; set; }
        [DataMember]
        public string BondStatus { get; set; }
        [DataMember]
        public string Bank { get; set; }
        [DataMember]
        public Nullable<DateTime> SalesBondClientAcceptDt { get; set; }
        [DataMember]
        public int? DaysLeft { get; set; }

    }
}
