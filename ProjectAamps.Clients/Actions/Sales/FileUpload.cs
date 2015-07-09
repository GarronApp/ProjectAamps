using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AAMPS.Clients.Actions.Sales
{
    public class FileUpload
    {
        public IEnumerable<HttpPostedFileBase> Files { get;set; }
    }
}
