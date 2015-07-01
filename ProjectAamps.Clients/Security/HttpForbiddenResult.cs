using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AAMPS.Clients.Security
{
    public class HttpForbiddenResult : HttpStatusCodeResult
    {
        public HttpForbiddenResult()
            : this(null)
        {
        }

        public HttpForbiddenResult(string statusDescription)
            : base(403, statusDescription)
        {
        }
    }

    public class HandleForbiddenRedirect : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                var config = (CustomErrorsSection)
                               WebConfigurationManager.GetSection("system.web/customErrors");
                string urlToRedirectTo = config.Errors["403"].Redirect;
                filterContext.Result = new RedirectResult(urlToRedirectTo);
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
