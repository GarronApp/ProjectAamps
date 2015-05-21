﻿using AAMPS.Clients.Queries.Sales;
using AAMPS.Clients.ViewModels.Sales;
using App.Common.Controllers.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.Actions.Sales
{
    public class LoadNewSale : ControllerAction
    {
        public int Id { get; set; }
        public LoadSalesQuery query { get; set; }
        public LoadNewSale()
         {

         }

          public LoadNewSale(LoadSalesQuery _query)
              : base(_query)
        {
            query = _query;
            OnBindModel();
        }

        public override void OnBindModel()
        {
            Id = query.UnitId;
            OnExecute();
        }

        public override object OnExecute()
        {
            var _currentUnit = new AAMPS.Clients.AampService.AampServiceClient().GetUnitById(Id);

            SalesViewModel viewModel = new SalesViewModel();

            viewModel.IsNewSale = "NewSale";
            viewModel.UnitNumber = _currentUnit.UnitNumber;
            viewModel.UnitSize = _currentUnit.UnitSize;
            viewModel.UnitPrice = _currentUnit.UnitPrice;
            viewModel.UnitPriceIncluding = _currentUnit.UnitPriceIncluding;
            viewModel.CurrentSalesStatus = "Available";
            viewModel.UnitPhase = _currentUnit.UnitPhase;
            viewModel.UnitFloor = _currentUnit.UnitFloor;
            viewModel.PlotSize = _currentUnit.UnitErfSize;

            return viewModel;
        }
    }
}
