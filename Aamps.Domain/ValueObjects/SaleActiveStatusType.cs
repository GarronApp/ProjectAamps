using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.ValueObjects
{
    
    [DataContract]
    public class SaleActiveStatusType
    {

    [DataMember]
    public GetSaleActiveStatusType GetSaleActiveStatusTypes;

    [DataMember]
    public GetSaleStatusType GetSaleStatusTypes;

    }
}

    [DataContract]
    public enum GetSaleActiveStatusType
    {
        [EnumMember]
        Available = 1,
        [EnumMember]
        Reserved = 2,
        [EnumMember]
        Pending = 3,
        [EnumMember]
        Sold = 4,
        [EnumMember]
        Bankable = 5,
        [EnumMember]
        Registered = 6
    }

    [DataContract]
    public enum GetSaleStatusType
    {
        [EnumMember]
        Active = 1,
        [EnumMember]
        Cancelled = 2,
        [EnumMember]
        Declined = 3,
        [EnumMember]
        InActive = 4
    }

