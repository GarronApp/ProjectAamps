using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.ViewModels.User
{
    public class UserRightsViewModel
    {
        public bool UserRightFull { get; set; }
        public bool UserRightView { get; set; }
        public bool UserRightEdit { get; set; }
        public bool UserRightAdd { get; set; }
        public bool UserRightDelete { get; set; }
    }
}
