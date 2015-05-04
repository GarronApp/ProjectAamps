using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAMPS.Web.Models.ViewModels.Bonds
{
    public class OrginatorViewModel
    {
        public int OriginatorTrID { get; set; }
        public int CurrentOriginatorTrID { get; set; }
        public string ApplicationStatus { get; set; }
        public string BankName { get; set; }
        public string MOStatus { get; set; }
        public string OriginatorTrSubmittedDt { get; set; }
        public string OriginatorTrAIPDt { get; set; }
        public string OriginatorTrGrantDt { get; set; }
        public int OriginatorTrAcceptedBt { get; set; }
        public string OriginatorTrAcceptDt { get; set; }
        public double OriginatorTrBondAmount { get; set; }
        public double OriginatorTrIntRate { get; set; }
        public string OriginatorTrAddedDt { get; set; }
        public string OriginatorTrModifiedDt { get; set; }
    }
}