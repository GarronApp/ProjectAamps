using App.Common.Exceptions;
using App.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AAMPS.Clients.Security
{
    public class AuthProvider
    {
        public bool ValidateUser(string UserName, string Password)
        {

            AAMPS.Clients.AampService.AampServiceClient _serviceProvider = new AAMPS.Clients.AampService.AampServiceClient();
            try
            {
                var _currentUser = _serviceProvider.GetCurrentUser(UserName);

                if (_currentUser != null)
                {
                    if (!String.IsNullOrEmpty(Password))
                    {
                        string _tempPassword = Password.Trim();
                        var match = LoginValidationHandler.ValidatePasswords(_currentUser.UserListPassword, _tempPassword);
                        if (match)
                        {
                            var SessionIdentity = Guid.NewGuid();
                            System.Web.HttpContext.Current.Session.Add("CurrentUserSession", SessionIdentity);
                            System.Web.HttpContext.Current.Session.Add("CurrentUserId", _currentUser.UserListID);
                            System.Web.HttpContext.Current.Session.Add("USER", _currentUser);
                            System.Web.HttpContext.Current.Session.Add("CurrentUser", _currentUser.UserListName);
                            System.Web.HttpContext.Current.Session.Add("CurrentUserFullName", _currentUser.UserListName + " " + _currentUser.UserListSurname);

                            SetPermissionRights(_serviceProvider, _currentUser.UserListID);
                            return true;
                        }
                    }
                }
                _serviceProvider.Close();
            }
            catch (Exception ex)
            {
              
                _serviceProvider.Close();
            }
            finally
            {
                if (_serviceProvider.State != System.ServiceModel.CommunicationState.Closed)
                {
                    _serviceProvider.Abort();
                }
            }
            return false;
        }

        private void SetPermissionRights(AAMPS.Clients.AampService.AampServiceClient _serviceProvider, int userIdentity)
        {
            try
            {
                var UserRights = _serviceProvider.GetUserPermissions(userIdentity);

                var Read = Convert.ToInt32(UserRights.UserRightView);
                System.Web.HttpContext.Current.Session.Add("ReadAccess", Read);
                var Write = Convert.ToInt32(UserRights.UserRightAdd);
                System.Web.HttpContext.Current.Session.Add("WriteAccess", Write);
                var Delete = Convert.ToInt32(UserRights.UserRightDelete);
                System.Web.HttpContext.Current.Session.Add("DeleteAccess", Delete);
                var Edit = Convert.ToInt32(UserRights.UserRightEdit);
                System.Web.HttpContext.Current.Session.Add("EditAccess", Edit);
                var Full = Convert.ToInt32(UserRights.UserRightFull);
                System.Web.HttpContext.Current.Session.Add("FullAccess", Full);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
