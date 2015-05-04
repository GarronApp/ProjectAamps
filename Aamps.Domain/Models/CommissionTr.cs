using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class CommissionTr
    {
        [DataMember]
        public int CommissionTrID { get; set; }
        [DataMember]
        public int CommissionTypeID { get; set; }
        [DataMember]
        public int UserListID { get; set; }
        [DataMember]
        public double CommissionTrBondAmount { get; set; }
        [DataMember]
        public double CommissionTrRate { get; set; }
        [DataMember]
        public System.DateTime CommissionTrAddedDt { get; set; }
        [DataMember]
        public System.DateTime CommissionTrModifiedDt { get; set; }
        [DataMember]
        public int CommissionTrAddedByUser { get; set; }
        [DataMember]
        public int CommissionTrModifiedByUser { get; set; }
        [DataMember]
        public int SaleID { get; set; }
        [DataMember]
        public virtual Sale Sale { get; set; }
        [DataMember]
        public virtual CommissionType CommissionType { get; set; }
        [DataMember]
        public virtual UserList UserList { get; set; }
    }
}
