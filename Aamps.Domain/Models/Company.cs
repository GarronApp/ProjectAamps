using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class Company
    {
        public Company()
        {
            this.UserLists = new List<UserList>();
        }
        [DataMember]
        public int CompanyID { get; set; }
        [DataMember]
        public string CompanyDescription { get; set; }
        [DataMember]
        public int UserGroupID { get; set; }
        [DataMember]
        public virtual UserGroup UserGroup { get; set; }
        [DataMember]
        public virtual ICollection<UserList> UserLists { get; set; }
    }
}
