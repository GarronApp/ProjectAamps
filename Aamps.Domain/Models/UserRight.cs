using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class UserRight
    {
        [DataMember]
        public int UserRightID { get; set; }
        [DataMember]
        public int UserListID { get; set; }
        [DataMember]
        public int FormReportID { get; set; }
        [DataMember]
        public bool UserRightFull { get; set; }
        [DataMember]
        public bool UserRightView { get; set; }
        [DataMember]
        public bool UserRightEdit { get; set; }
        [DataMember]
        public bool UserRightAdd { get; set; }
        [DataMember]
        public bool UserRightDelete { get; set; }
        [DataMember]
        public System.DateTime UserRightDateAdded { get; set; }
        [DataMember]
        public System.DateTime UserRightDateModified { get; set; }
        [DataMember]
        public virtual FormReport FormReport { get; set; }
        [DataMember]
        public virtual UserList UserList { get; set; }
    }
}
