﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.ViewModels.Reports.Sales
{
    public class SalesReportViewModel
    {
        [DataMember]
        public string Development { get; set; }
        [DataMember]
        public string UnitNo { get; set; }
        [DataMember]
        public string Phase { get; set; }
        [DataMember]
        public double? Price { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Agency { get; set; }
        [DataMember]
        public string Agent { get; set; }
        [DataMember]
        public string Purchaser { get; set; }
        [DataMember]
        public double? Deposit { get; set; }
        [DataMember]
        public DateTime DepositDate { get; set; }
        //[DataMember]
        //public string Proof { get; set; }
        //[DataMember]
        //public Nullable<System.DateTime> CntrSigned { get; set; }
        //[DataMember]
        //public string Bond { get; set; }
        //[DataMember]
        //public double? BondReq { get; set; }
        //[DataMember]
        //public double? BondAmountGrant { get; set; }
        //[DataMember]
        //public Nullable<System.DateTime> Granted { get; set; }
        //[DataMember]
        //public double? AmountDue { get; set; }

    }
}
