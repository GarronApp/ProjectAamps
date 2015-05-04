using AAMPS.Clients.AampService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAMPS.Web.Models.ViewModels.Development.Dashboard
{
    public class DevelopmentUnitViewModel
    {
        public int DevelopmentID { get; set; }
        public string DevelopmentDescription { get; set; }
        public string EstateName { get; set; }
        public int TotalUnits { get; set; }

    }
}