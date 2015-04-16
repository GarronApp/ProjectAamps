using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class UserType
    {
        public UserType()
        {
            this.UserLists = new List<UserList>();
        }
        [DataMember]
        public int UserTypeID { get; set; }
        [DataMember]
        public string UserTypeDescription { get; set; }
        [DataMember]
        public virtual ICollection<UserList> UserLists { get; set; }
    }
}
