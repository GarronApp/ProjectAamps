using AAMPS.Clients.AampService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.ViewModels.Development
{
    public class DevelopmentViewModel
    {
        public int DevelopmentID { get; set; }
        public string DevelopmentDescription { get; set; }
        public int EstateID { get; set; }
        public int UnitStatusId { get; set; }
        public int DevelopmentTypeID { get; set; }
        public bool DevelopmentInActive { get; set; }
        public int DevelopmentDevID { get; set; }
        public int DevelopmentTransAttID { get; set; }
        public int DevelopmentSalesCoID { get; set; }
        public string DevelopmentUrlImage { get; set; }
        public virtual DevelopmentType DevelopmentType { get; set; }
        public virtual Estate Estate { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
        public int UnitId { get; set; }
        public string UnitNumber { get; set; }
        public string UnitFloor { get; set; }
        public string UnitBlock { get; set; }
        public string UnitPhase { get; set; }
        public int UnitTypeID { get; set; }
        public double UnitSize { get; set; }
        public double UnitErfSize { get; set; }
        public double UnitPrice { get; set; }
        public double UnitPriceVat { get; set; }
        public double UnitPriceIncluding { get; set; }
        public string UnitStatusID { get; set; }
        public int AvailableStatusCount { get; set; }
        public int PendingStatusCount { get; set; }
        public int ReservedStatusCount { get; set; }
        public int SoldStatusCount { get; set; }
        public int TotalUnitsCount { get; set; }
        public Nullable<System.DateTime> UnitActiveDate { get; set; }
    }
}
