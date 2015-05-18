using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Master
{
    public partial class Estate
    {
        public Estate()
        {
            this.Developments = new List<Development>();
        }

        public int EstateID { get; set; }
        public string EstateDescription { get; set; }
        public virtual ICollection<Development> Developments { get; set; }
    }
}
