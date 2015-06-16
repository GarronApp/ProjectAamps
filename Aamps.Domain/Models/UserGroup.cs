using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            this.Companies = new List<Company>();
            this.GroupRights = new List<GroupRight>();
        }
        [DataMember]
        public int UserGroupID { get; set; }
        [DataMember]
        public string UserGroupDescription { get; set; }
        [DataMember]
        public virtual ICollection<Company> Companies { get; set; }
        [DataMember]
        public virtual ICollection<GroupRight> GroupRights { get; set; }

    }
}
