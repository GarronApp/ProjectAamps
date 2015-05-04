using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class FormReport
    {
        public FormReport()
        {
            this.GroupRights = new List<GroupRight>();
            this.UserRights = new List<UserRight>();
        }
        [DataMember]
        public int FormReportID { get; set; }
        [DataMember]
        public string FormReportDescription { get; set; }
        [DataMember]
        public bool FormReportIsForm { get; set; }
        [DataMember]
        public virtual ICollection<GroupRight> GroupRights { get; set; }
        [DataMember]
        public virtual ICollection<UserRight> UserRights { get; set; }
    }
}
