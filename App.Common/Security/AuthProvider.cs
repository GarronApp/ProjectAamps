using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Security
{
    public class AuthProvider
    {
        public bool ValidateUser(string UserName, string Password)
        {
            GetSavi_Mobile.CustomerService.CustomerServiceClient userClient = new GetSavi_Mobile.CustomerService.CustomerServiceClient();
            userClient.ClientCredentials.UserName.UserName = "CRMAgent";
            userClient.ClientCredentials.UserName.Password = "password1!";
            try
            {

                GetSavi_Mobile.CustomerService.User user = new GetSavi_Mobile.CustomerService.User();

                user = userClient.UserSelect(UserName, "ID");

                if (user != null)
                {

                    string salt = user.PasswordSalt;
                    string hashedpassword = HashPassword(salt, Password);
                    if (hashedpassword == user.Password)
                    {
                        return true;
                    }

                }
                userClient.Close();
            }
            catch (Exception exc)
            {
                HandleException(exc);
                userClient.Close();
            }
            finally
            {
                if (userClient.State != System.ServiceModel.CommunicationState.Closed)
                {
                    userClient.Abort();
                }
            }
            return false;
        }
    }
}
