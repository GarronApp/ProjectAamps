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
            return Json(new { Forbidden = true, newurl = Url.Action("Forbidden","Error")}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Forbidden()
        {
            return View();
        }
    }
}