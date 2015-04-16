using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.UserCompanies
{
    public partial class FormReport
    {
        public FormReport()
        {
            this.GroupRights = new List<GroupRight>();
            this.UserRights = new List<UserRight>();
        }

        public int FormReportID { get; set; }
        public string FormReportDescription { get; set; }
        public bool FormReportIsForm { get; set; }
        public virtual ICollection<GroupRight> GroupRights { get; set; }
        public virtual ICollection<UserRight> UserRights { get; set; }
    }
}
