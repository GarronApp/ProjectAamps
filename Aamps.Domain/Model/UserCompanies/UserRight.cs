using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.UserCompanies
{
    public partial class UserRight
    {
        public int UserRightID { get; set; }
        public int UserListID { get; set; }
        public int FormReportID { get; set; }
        public bool UserRightFull { get; set; }
        public bool UserRightView { get; set; }
        public bool UserRightEdit { get; set; }
        public bool UserRightAdd { get; set; }
        public bool UserRightDelete { get; set; }
        public System.DateTime UserRightDateAdded { get; set; }
        public System.DateTime UserRightDateModified { get; set; }
        public virtual FormReport FormReport { get; set; }
        public virtual UserList UserList { get; set; }
    }
}
