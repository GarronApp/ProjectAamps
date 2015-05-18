using Aamps.Domain.Model.Sales;
using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.UserCompanies
{
    public partial class Company
    {
        public Company()
        {
            this.Sales = new List<Sale>();
            this.UserLists = new List<UserList>();
        }

        public int CompanyID { get; set; }
        public string CompanyDescription { get; set; }
        public int UserGroupID { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual UserGroup UserGroup { get; set; }
        public virtual ICollection<UserList> UserLists { get; set; }
    }
}
