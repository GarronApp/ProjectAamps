using Aamps.Domain.Model.Master;
using Aamps.Domain.Model.Sales;
using Aamps.Domain.Model.UserCompanies;
using System;
using System.Collections.Generic;

namespace Aamps.Domain.Model.Units
{
    public partial class Unit
    {
        public Unit()
        {
            this.Sales = new List<Sale>();
        }

        public int UnitID { get; set; }
        public string UnitNumber { get; set; }
        public int DevelopmentID { get; set; }
        public string UnitFloor { get; set; }
        public string UnitBlock { get; set; }
        public int UnitTypeID { get; set; }
        public double UnitSize { get; set; }
        public double UnitErfSize { get; set; }
        public double UnitPrice { get; set; }
        public double UnitPriceVat { get; set; }
        public double UnitPriceIncluding { get; set; }
        public int UnitStatusID { get; set; }
        public Nullable<System.DateTime> UnitActiveDate { get; set; }
        public System.DateTime UnitDateAdded { get; set; }
        public System.DateTime UnitDateModified { get; set; }
        public int UnitAddedByUser { get; set; }
        public int UnitModifiedByUser { get; set; }
        public virtual Development Development { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual UserList UserList { get; set; }
        public virtual UnitStatus UnitStatus { get; set; }
        public virtual UnitType UnitType { get; set; }
    }
}
