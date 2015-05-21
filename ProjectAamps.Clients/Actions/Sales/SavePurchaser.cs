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

        public PurchaserViewModel newPurchaser { get; set; }

        public SavePurchaser()
        {

        }
        public SavePurchaser(PurchaserViewModel _newPurchaser)
            : base(_newPurchaser)
        {
            newPurchaser = _newPurchaser;
            OnBindModel();
        }

        public override void OnBindModel()
        {
            IsNewPurchaser = newPurchaser.IsNewIdentity;

            if (IsNewPurchaser)
                OnExecute();
        }

        public override object OnExecute()
        {
            var _purchaser = new Purchaser();

            _purchaser.EntityTypeID = newPurchaser.EntityTypeID;
            _purchaser.PurchaserDescription = newPurchaser.PurchaserDescription;
            _purchaser.PurchaserContactPerson = newPurchaser.PurchaserContactPerson;
            _purchaser.PurchaserContactHome = newPurchaser.PurchaserContactHome;
            _purchaser.PurchaserContactCell = newPurchaser.PurchaserContactCell;
            _purchaser.PurchaserContactWork = newPurchaser.PurchaserContactWork;
            _purchaser.PurchaserEmail = newPurchaser.PurchaserEmail;
            _purchaser.PurchaserAddress = newPurchaser.PurchaserAddress;
            _purchaser.PurchaserAddress1 = newPurchaser.PurchaserAddress1;
            _purchaser.PurchaserAddress2 = newPurchaser.PurchaserAddress2;
            _purchaser.PurchaserSuburb = newPurchaser.PurchaserSuburb;
            _purchaser.PurchaserPostalCode = newPurchaser.PurchaserPostalCode;
            _purchaser.PurchaserRegID = Guid.NewGuid().ToString().Substring(0, 8);

            var result =  new AampServiceClient().SavePurchaser(_purchaser);
            _purchaser.PurchaserID = result.PurchaserID;

            return _purchaser;
        }

    }
}
