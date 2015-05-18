using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.UserCompanies
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            this.Companies = new List<Company>();
            this.GroupRights = new List<GroupRight>();
            this.UserLists = new List<UserList>();
        }

        public int UserGroupID { get; set; }
        public string UserGroupDescription { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<GroupRight> GroupRights { get; set; }
        public virtual ICollection<UserList> UserLists { get; set; }
    }
}
