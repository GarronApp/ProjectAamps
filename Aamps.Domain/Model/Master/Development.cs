using Aamps.Domain.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Master
{
    public partial class Development
    {
        public Development()
        {
            this.Units = new List<Unit>();
        }

        public int DevelopmentID { get; set; }
        public string DevelopmentDescription { get; set; }
        public int EstateID { get; set; }
        public int DevelopmentTypeID { get; set; }
        public bool DevelopmentInActive { get; set; }
        public virtual DevelopmentType DevelopmentType { get; set; }
        public virtual Estate Estate { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
