using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Master
{
    public partial class CommentGroup
    {
        public CommentGroup()
        {
            this.Comments = new List<Comment>();
        }

        public int CommentGroupID { get; set; }
        public string CommentGroupDescription { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
