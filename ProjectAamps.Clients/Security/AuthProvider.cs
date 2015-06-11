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
                            System.Web.HttpContext.Current.Session.Add("CurrentUser", _currentUser.UserListName);
                            System.Web.HttpContext.Current.Session.Add("CurrentUserFullName", _currentUser.UserListName + " " + _currentUser.UserListSurname);
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
    }
}
