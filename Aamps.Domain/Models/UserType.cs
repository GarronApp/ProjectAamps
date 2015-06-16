using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class UserType
    {
        public UserType()
        {
        }
        [DataMember]
        public int UserTypeID { get; set; }
        [DataMember]
        public string UserTypeDescription { get; set; }

    }
}
