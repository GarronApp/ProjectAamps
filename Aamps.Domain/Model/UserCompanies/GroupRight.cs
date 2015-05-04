using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.UserCompanies
{
    public partial class GroupRight
    {
        public int GroupRightID { get; set; }
        public int UserGroupID { get; set; }
        public int FormReportID { get; set; }
        public bool GroupRightFull { get; set; }
        public bool GroupRightView { get; set; }
        public bool GroupRightEdit { get; set; }
        public bool GroupRightAdd { get; set; }
        public bool GroupRightDelete { get; set; }
        public System.DateTime GroupRightDateAdded { get; set; }
        public System.DateTime GroupRightDateModified { get; set; }
        public virtual FormReport FormReport { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
