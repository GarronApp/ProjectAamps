﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAMPS.Web.Models.ViewModels.Sales
{
    public class ReservationViewModel
    {
        public int SaleStatusId { get; set; }
        public int UnitStatusId { get; set; }
        public int CurrentIndividualID { get; set; }
        public string CurrentSalesStatus { get; set; }
        public string SaleReservationDt { get; set; }
        public string SaleReservationExpiryDt { get; set; }
        public string SaleReservationExtentionDt { get; set; }
    }
}