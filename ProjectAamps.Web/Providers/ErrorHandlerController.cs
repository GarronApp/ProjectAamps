using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AAMPS.Web.Providers
{
    public class ErrorHandlerController : Controller
    {
        // GET: ErrorHandler
        public JsonResult Index()
        {
            var context = HttpContext;
            context.Response.StatusCode = 401;
            context.Response.StatusDescription = "You do not have permission to perform this action";
            context.Response.End();
            return Json(context);
        }
    }
}