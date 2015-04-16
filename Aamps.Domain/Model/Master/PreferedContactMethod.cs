using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Master
{
    public partial class PreferedContactMethod
    {
        public PreferedContactMethod()
        {
            this.Individuals = new List<Individual>();
        }

        public int PreferedContactMethodID { get; set; }
        public string PreferedContactMethodDescription { get; set; }
        public virtual ICollection<Individual> Individuals { get; set; }
    }
}
