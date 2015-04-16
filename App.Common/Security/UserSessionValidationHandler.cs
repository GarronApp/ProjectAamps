using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Common.Security
{
    public class UserSessionValidationHandler
    {
        public bool ValidateLogin()
        {
            try
            {
                if (System.Web.HttpContext.Current.Session["CurrentUserSession"] != null)
                {
                    return true;
                }
            }
            catch (Exception exc)
            {
                App.Common.Exceptions.ExceptionHandler.HandleException(exc);
                HttpContext.Current.Response.Redirect("~/Account/Login");
            }

            return false;
        }
    }
}
