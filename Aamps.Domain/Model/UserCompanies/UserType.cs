using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.UserCompanies
{
    public partial class UserType
    {
        public UserType()
        {
            this.UserLists = new List<UserList>();
        }

        public int UserTypeID { get; set; }
        public string UserTypeDescription { get; set; }
        public virtual ICollection<UserList> UserLists { get; set; }
    }
}
