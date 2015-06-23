using AAMPS.Clients.AampService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using App.Extentions;
using System.Web.Routing;

namespace AAMPS.Clients.Security
{
    public class AuthPermission : AuthorizeAttribute
    {
        private readonly IEnumerable<Permissions> required;

        private const int hasAccess = 1;

        private bool HasRights = false;

        AAMPS.Clients.AampService.AampServiceClient _serviceProvider = new AAMPS.Clients.AampService.AampServiceClient();

        public AuthPermission(params Permissions[] required)
        {
            this.required = required;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if(!HasRights)
            {
                if(filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    JsonResult UnauthorizedResult = new JsonResult();
                    UnauthorizedResult.Data = (new { PermissionStatus = "Unauthorized", Code = "401", description = "You do not have permission to perform this action" });
                    UnauthorizedResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    filterContext.Result = UnauthorizedResult;
                }
               
            }

        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            try
            {
                var identity = (int)httpContext.Session["CurrentUserId"];

                var user = httpContext.Session["USER"];

                if (user.IsNotNull())
                {
                    if (HasPermission(required, httpContext))
                    {
                        HasRights = true;
                        return true;
                    }
                    else
                    {
                        HasRights = false;
                    }
                }

            }
            catch (Exception exc)
            {

            }

            return false;
        }

        public bool HasPermission(IEnumerable<Permissions> rights, System.Web.HttpContextBase context)
        {
            foreach (var permission in rights)
            {
                switch (permission)
                {
                    case Permissions.View:
                        {
                            var readAccess = SafeCastSessionProperty(context.Session["ReadAccess"]);

                            if (readAccess == hasAccess)
                            {
                                return true;
                            }
                            return false;
                        }
                    case Permissions.Add:
                        {
                            var writeAccess = SafeCastSessionProperty(context.Session["WriteAccess"]);

                            if (writeAccess == hasAccess)
                            {
                                return true;
                            }
                            return false;
                        }
                    case Permissions.Delete:
                        {
                            var deleteAccess = SafeCastSessionProperty(context.Session["DeleteAccess"]);

                            if (deleteAccess == hasAccess)
                            {
                                return true;
                            }
                            return false;
                        }
                    case Permissions.Edit:
                        {
                            var editAccess = SafeCastSessionProperty(context.Session["EditAccess"]);

                            if (editAccess == hasAccess)
                            {
                                return true;
                            }
                            return false;
                        }
                    case Permissions.Add|Permissions.Edit:
                        {
                            var writeAccess = SafeCastSessionProperty(context.Session["WriteAccess"]);
                            var editAccess = SafeCastSessionProperty(context.Session["EditAccess"]);

                            if (writeAccess == hasAccess && editAccess == hasAccess)
                            {
                                return true;
                            }
                            return false;
                        }
                    case Permissions.Admin:
                        {
                            var fullAccess = SafeCastSessionProperty(context.Session["FullAccess"]);

                            if (fullAccess == hasAccess)
                            {
                                return true;
                            }
                            return false;
                        }
                    default:
                        break;
                }
            }

            return false;

        }

       private int SafeCastSessionProperty(object val)
        {
            return (int)val;
        }

    }

    public class User
    {
        public Permissions Permissions { get; set; }
    }

    public static class EnumerationExtensions
    {

        //checks to see if an enumerated value contains a type
        public static bool Has<T>(this System.Enum type, T value)
        {
            try
            {
                return (((int)(object)type & (int)(object)value) == (int)(object)value);
            }
            catch
            {
                return false;
            }
        }
    }

  
}
