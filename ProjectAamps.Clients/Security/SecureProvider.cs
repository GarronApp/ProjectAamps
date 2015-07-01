using AAMPS.Clients.AampService;
using App.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Extentions;

namespace AAMPS.Clients.Security
{
    public class SecureProvider
    {
        public AAMPS.Clients.AampService.AampServiceClient _service;

        public List<object> UserRights;

         public SecureProvider()
         {
         }

        public AAMPS.Clients.AampService.AampServiceClient _serviceProvider
        {
            get
            {
                return _service = new AampServiceClient();
            }
        }

        public UserList USER
        {
            get
            {
                var user = SessionHandler.GetSessionObject("USER");

                if (user.IsNotNull())
                {
                    return user as UserList;
                }

                return null;
            }

        }

        public void LoadPermissions()
        {
            var rights = _serviceProvider.GetUserPermissions(USER.UserListID);

            if(rights.IsNotNull())
            {
                SessionHandler.SessionContext("USER_RIGHT_VIEW", rights.UserRightView);
                SessionHandler.SessionContext("USER_RIGHT_ADD", rights.UserRightAdd);
                SessionHandler.SessionContext("USER_RIGHT_EDIT", rights.UserRightEdit);
                SessionHandler.SessionContext("USER_RIGHT_DELETE", rights.UserRightDelete);
            }
            
        }
    }
}
