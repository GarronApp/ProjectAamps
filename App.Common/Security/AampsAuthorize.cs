using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.Common.Security
{
    public class AampsAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            try
            {
                if (httpContext.Session["CurrentUserSession"] != null)
                {
                    return true;
                }
            }
            catch (Exception exc)
            {
                App.Common.Exceptions.ExceptionHandler.HandleException(exc);
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Account",
                            action = "Login"
                        })
                    );
        }

    }
}
