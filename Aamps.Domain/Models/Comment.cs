using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class Comment
    {
        [DataMember]
        public int CommentID { get; set; }
        [DataMember]
        public string CommentDetails { get; set; }
        [DataMember]
        public System.DateTime CommentAddedDt { get; set; }
        [DataMember]
        public int CommentAddedByUser { get; set; }
        [DataMember]
        public int CommentGroupID { get; set; }
        [DataMember]
        public Nullable<int> SaleID { get; set; }
        [DataMember]
        public Nullable<int> BondAttID { get; set; }
        [DataMember]
        public Nullable<int> TransAttID { get; set; }
        [DataMember]
        public virtual BondAtt BondAtt { get; set; }
        [DataMember]
        public virtual CommentGroup CommentGroup { get; set; }
        [DataMember]
        public virtual Sale Sale { get; set; }
        [DataMember]
        public virtual TransAtt TransAtt { get; set; }
    }
}
