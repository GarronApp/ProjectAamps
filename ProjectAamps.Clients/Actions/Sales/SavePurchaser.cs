using AAMPS.Clients.AampService;
using AAMPS.Clients.Queries.Sales;
using AAMPS.Clients.ViewModels.Purchaser;
using App.Common.Controllers.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAamps.Clients.Actions.Sales
{
    public class SavePurchaser : ControllerAction
    {
        public bool IsNewPurchaser { get; set; }

        public PurchaserViewModel newPurchaserViewModel { get; set; }

        public SavePurchaser()
        {

        }
        public SavePurchaser(PurchaserViewModel _newPurchaser)
            : base(_newPurchaser)
        {
            newPurchaserViewModel = _newPurchaser;
            OnBindModel();
        }

        public override void OnBindModel()
        {
            IsNewPurchaser = newPurchaserViewModel.IsNewIdentity;

            if (IsNewPurchaser)
                OnExecute();
        }

        public override object OnExecute()
        {
            var _purchaser = new Purchaser();

            _purchaser.EntityTypeID = newPurchaserViewModel.EntityTypeID;
            _purchaser.PurchaserDescription = newPurchaserViewModel.PurchaserDescription;
            _purchaser.PurchaserContactPerson = newPurchaserViewModel.PurchaserContactPerson;
            _purchaser.PurchaserContactHome = newPurchaserViewModel.PurchaserContactHome;
            _purchaser.PurchaserContactCell = newPurchaserViewModel.PurchaserContactCell;
            _purchaser.PurchaserContactWork = newPurchaserViewModel.PurchaserContactWork;
            _purchaser.PurchaserEmail = newPurchaserViewModel.PurchaserEmail;
            _purchaser.PurchaserAddress = newPurchaserViewModel.PurchaserAddress;
            _purchaser.PurchaserAddress1 = newPurchaserViewModel.PurchaserAddress1;
            _purchaser.PurchaserAddress2 = newPurchaserViewModel.PurchaserAddress2;
            _purchaser.PurchaserSuburb = newPurchaserViewModel.PurchaserSuburb;
            _purchaser.PurchaserPostalCode = newPurchaserViewModel.PurchaserPostalCode;
            _purchaser.PurchaserRegID = Guid.NewGuid().ToString().Substring(0, 8);

            var result =  new AampServiceClient().SavePurchaser(_purchaser);
            _purchaser.PurchaserID = result.PurchaserID;
            newPurchaserViewModel.PurchaserID = result.PurchaserID;

            return _purchaser;
        }

    }
}
