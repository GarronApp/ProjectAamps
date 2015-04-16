using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.Units
{
    public partial class UnitStatus
    {
        public UnitStatus()
        {
            this.Units = new List<Unit>();
        }

        public int UnitStatusID { get; set; }
        public string UnitStatusDescription { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
