using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.ViewModels.Purchaser
{
    public class PurchaserViewModel
    {
        public int PurchaserID { get; set; }
        public int EntityTypeID { get; set; }
        public string PurchaserDescription { get; set; }
        public string PurchaserRegID { get; set; }
        public string PurchaserContactPerson { get; set; }
        public string PurchaserContactCell { get; set; }
        public string PurchaserContactHome { get; set; }
        public string PurchaserContactWork { get; set; }
        public string PurchaserEmail { get; set; }
        public string PurchaserAddress { get; set; }
        public string PurchaserAddress1 { get; set; }
        public string PurchaserAddress2 { get; set; }
        public string PurchaserAddress3 { get; set; }
        public string PurchaserPostalCode { get; set; }
        public string PurchaserSuburb { get; set; }
    }
}
