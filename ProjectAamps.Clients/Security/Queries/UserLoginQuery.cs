using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.Security.Queries
{
    public class UserLoginQuery
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateStamp { get; set; }
    }
}
