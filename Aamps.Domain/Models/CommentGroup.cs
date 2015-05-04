using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class CommentGroup
    {
        public CommentGroup()
        {
            this.Comments = new List<Comment>();
        }
        [DataMember]
        public int CommentGroupID { get; set; }
        [DataMember]
        public string CommentGroupDescription { get; set; }
        [DataMember]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
