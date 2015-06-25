using App.Common.Exceptions;
using App.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using App.Extentions;
using App.Common.Security;


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

                if (_currentUser.IsNotNull())
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
                ExceptionHandler.HandleException(ex);
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

                if (UserRights.IsNotNull())
                {

                    var Read = Convert.ToInt32(UserRights.UserRightView);
                    SessionHandler.SessionContext("ReadAccess", Read);
                    var Write = Convert.ToInt32(UserRights.UserRightAdd);
                    SessionHandler.SessionContext("WriteAccess", Write);
                    var Delete = Convert.ToInt32(UserRights.UserRightDelete);
                    SessionHandler.SessionContext("DeleteAccess", Delete);
                    var Edit = Convert.ToInt32(UserRights.UserRightEdit);
                    SessionHandler.SessionContext("EditAccess", Edit);
                    var Full = Convert.ToInt32(UserRights.UserRightFull);
                    SessionHandler.SessionContext("FullAccess", Full);
                }
               
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            
        }
    }
}
