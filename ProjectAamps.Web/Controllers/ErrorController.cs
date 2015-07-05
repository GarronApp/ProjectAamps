using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AAMPS.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public JsonResult Unauthorized()
        {
            throw new HttpException(403, "");
            //return Json(new { Forbidden = true, status = "403", statusText = "You do not have the permissions to do this action"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Forbidden()
        {
            return View();
        }

        public ActionResult PageNotFound()
        {
            return View();
        }
        public ActionResult SystemError()
        {
            return View();
        }
    }
}