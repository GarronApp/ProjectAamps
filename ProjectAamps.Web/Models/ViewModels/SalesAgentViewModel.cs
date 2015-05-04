using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAMPS.Web.Models.ViewModels
{
    public class SalesAgentViewModel
    {
        public string Agent { get; set; }
        public string Agency { get; set; }
        public string AgentContactNo { get; set; }
        public string AgentEmailNo { get; set; }
        public string AgentIdNumber { get; set; }
        public DateTime? ReservationLapses { get; set; }
        public DateTime? ReservationTimeExtention { get; set; }
        public string CommentOnExtention { get; set; }
        public bool ReferralDue { get; set; }
        public bool DepositPaid { get; set; }
        public bool ContractSigned { get; set; }
        public DateTime? PendingLapses { get; set; }
        public float SellingPriceInclVAT { get; set; }
        public float CommissionDue { get; set; }
        public DateTime? DateSignedBySeller { get; set; }
        public bool BondRequired { get; set; }
        public float CashPayment { get; set; }

        public string IndividualFirstName { get; set; }
        public string IndividualLastName { get; set; }
        public string IndividualCellNo { get; set; }
        public string IndividualWorkNo { get; set; }
        public int IndividualContactMethod { get; set; }
        public string IndividualEmailAddress { get; set; }

        public string Development { get; set; }
        public string UnitNumber { get; set; }
        public double PlotSize { get; set; }
        public double UnitPrice { get; set; }
        public double UnitSize { get; set; }
        public string UnitPhase { get; set; }
        public string UnitFloor { get; set; }

        




    }
}