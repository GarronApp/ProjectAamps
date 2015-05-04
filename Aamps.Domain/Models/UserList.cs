using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class UserList
    {
        public UserList()
        {
            this.CommissionTrs = new List<CommissionTr>();
            this.UserRights = new List<UserRight>();
        }
        [DataMember]
        public int UserListID { get; set; }
        [DataMember]
        public string UserListName { get; set; }
        [DataMember]
        public string UserListSurname { get; set; }
        [DataMember]
        public string UserListPassword { get; set; }
        [DataMember]
        public string UserListEmail { get; set; }
        [DataMember]
        public int UserTypeID { get; set; }
        [DataMember]
        public int CompanyID { get; set; }
        [DataMember]
        public int UserGroupID { get; set; }
        [DataMember]
        public int UserListAddedby { get; set; }
        [DataMember]
        public int UserListLastModifiedby { get; set; }
        [DataMember]
        public System.DateTime UserListDateAdded { get; set; }
        [DataMember]
        public System.DateTime UserListDateModified { get; set; }
        [DataMember]
        public bool UserListInActive { get; set; }
        [DataMember]
        public virtual ICollection<CommissionTr> CommissionTrs { get; set; }
        [DataMember]
        public virtual Company Company { get; set; }
        [DataMember]
        public virtual UserGroup UserGroup { get; set; }
        [DataMember]
        public virtual UserType UserType { get; set; }
        [DataMember]
        public virtual ICollection<UserRight> UserRights { get; set; }
        
    }
}
