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
using AAMPS.Clients.Security;


namespace AAMPS.Clients.Security
{
    public class AuthProvider : SecureProvider
    {
        public bool ValidateUser(string UserName, string Password)
        {

            try
            {
                var _currentUser = base._serviceProvider.GetCurrentUser(UserName);
                
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
                            base.LoadPermissions();
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

     
    }
}
