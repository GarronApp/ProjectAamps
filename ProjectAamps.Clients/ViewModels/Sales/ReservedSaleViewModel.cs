﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.ViewModels.Sales
{
    public class ReservedSaleViewModel
    {
        public int SaleStatusId { get; set; }
        public int UnitStatusId { get; set; }
        public string CurrentSalesStatus { get; set; }
        public string SaleContractSignedPurchaserDt { get; set; }
        public int SalesDepositProofID { get; set; }
        public int SalesDepositProofBt { get; set; }
        public string SalesDepositProofDt { get; set; }
        public double SalesBondAmount { get; set; }
        public double SalesTotalDepositAmount { get; set; }
        public string SalesDepoistPaidDt { get; set; }
        public int SaleDepositPaidBt { get; set; }
        public int PendingFormCompleteAndValid { get; set; }




    }
}
