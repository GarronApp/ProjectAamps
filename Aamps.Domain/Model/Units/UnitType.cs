using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.Units
{
    public partial class UnitType
    {
        public UnitType()
        {
            this.Units = new List<Unit>();
        }

        public int UnitTypeID { get; set; }
        public string UnitTypeDescription { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
