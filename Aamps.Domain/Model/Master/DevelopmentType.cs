using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Master
{
    public partial class DevelopmentType
    {
        public DevelopmentType()
        {
            this.Developments = new List<Development>();
        }

        public int DevelopmentTypeID { get; set; }
        public string DevelopmentTypeDescription { get; set; }
        public virtual ICollection<Development> Developments { get; set; }
    }
}
