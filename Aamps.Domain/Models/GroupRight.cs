using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class GroupRight
    {
        [DataMember]
        public int GroupRightID { get; set; }
        [DataMember]
        public int UserGroupID { get; set; }
        [DataMember]
        public int FormReportID { get; set; }
        [DataMember]
        public bool GroupRightFull { get; set; }
        [DataMember]
        public bool GroupRightView { get; set; }
        [DataMember]
        public bool GroupRightEdit { get; set; }
        [DataMember]
        public bool GroupRightAdd { get; set; }
        [DataMember]
        public bool GroupRightDelete { get; set; }
        [DataMember]
        public System.DateTime GroupRightDateAdded { get; set; }
        [DataMember]
        public System.DateTime GroupRightDateModified { get; set; }
        [DataMember]
        public virtual FormReport FormReport { get; set; }
        [DataMember]
        public virtual UserGroup UserGroup { get; set; }
    }
}
