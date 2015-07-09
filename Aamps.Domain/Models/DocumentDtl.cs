using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Models
{
    public partial class DocumentDtl
    {
        [DataMember]
        public int DocumentDtlID { get; set; }
        [DataMember]
        public Nullable<System.Guid> DocumentDtlGUID { get; set; }
        [DataMember]
        public string DocumentDtlPath { get; set; }
        [DataMember]
        public string DocumentDtlName { get; set; }
        [DataMember]
        public Nullable<int> SalesID { get; set; }
        [DataMember]
        public Nullable<int> IndividualID { get; set; }
        [DataMember]
        public Nullable<int> PurchaserID { get; set; }
        [DataMember]
        public Nullable<int> OriginatorID { get; set; }
        [DataMember]
        public Nullable<int> FinancialTr { get; set; }
        [DataMember]
        public Nullable<int> UnitID { get; set; }
        [DataMember]
        public Nullable<int> TransferID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DocumentDtlAddedDt { get; set; }
        [DataMember]
        public Nullable<int> DocumenDtltAddedUserID { get; set; }
    }
}


