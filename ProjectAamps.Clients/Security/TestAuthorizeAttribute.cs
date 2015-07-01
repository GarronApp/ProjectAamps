using AAMPS.Clients.AampService;
using AAMPS.Clients.Security;
using App.Common.Security;
using App.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AAMPS.Clients.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class TestAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly List<Permissions> _permissions;

        private bool checkPermissions = false;

        private bool HasRights = false;

        public AAMPS.Clients.AampService.AampServiceClient _serviceProvider = new AAMPS.Clients.AampService.AampServiceClient();

        public TestAuthorizeAttribute(params object[] permissions)
        {
            if (permissions.Any(r => r.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("permissions");

            this._permissions = permissions[0].ToString().Split(',')
                .Select(flag => (Permissions)Enum.Parse(typeof(Permissions), flag))
                .ToList();

        }
        public TestAuthorizeAttribute()
        {
        }
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
           try
            {
                if (httpContext == null)
                    throw new ArgumentNullException("httpContext");

                if (USER.IsNull())
                    return false;


                if (_permissions.IsNotNull() && _permissions.HasItems())
                {
                    checkPermissions = true;

                    foreach (var permisssion in _permissions)
                    {
                        var hasPermission = 0;

                        if (permisssion == Permissions.View)
                        {
                            hasPermission = SessionHandler.CastSessionToInt(httpContext.Session["USER_RIGHT_VIEW"].ToString());
                            return HandlePermission(hasPermission);
                        }
                        if (permisssion == Permissions.Add)
                        {
                            hasPermission = SessionHandler.CastSessionToInt(httpContext.Session["USER_RIGHT_ADD"].ToString());
                            return HandlePermission(hasPermission);
                        }
                        if (permisssion == Permissions.Edit)
                        {
                            hasPermission = SessionHandler.CastSessionToInt(httpContext.Session["USER_RIGHT_EDIT"].ToString());
                            return HandlePermission(hasPermission);
                        }
                        if (permisssion == Permissions.Delete)
                        {
                            hasPermission = SessionHandler.CastSessionToInt(httpContext.Session["USER_RIGHT_DELETE"].ToString());
                            return HandlePermission(hasPermission);
                        }

                    }
                }
                else
                {
                    HasRights = false;
                    return false;
                }

            }
            catch(Exception ex)
            {
                
            }

            return false;

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (USER.IsNull())
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

            if (checkPermissions && !HasRights)
            {
                //filterContext.HttpContext.Response.StatusCode = 403;
                //filterContext.Result = new HttpStatusCodeResult(403, "Forbidden");
                //filterContext.HttpContext.Response.StatusDescription = "You do not have permission to perform this action";
                //filterContext.HttpContext.Response.End();

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    //new System.Web.Mvc.HttpStatusCodeResult(403,"forbidden");
                    //return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Bad Request");
                    //filterContext.HttpContext.Response.StatusCode = 403;
                    filterContext.Result = new HttpStatusCodeResult(403, "Forbidden");
                    //filterContext.HttpContext.Response.StatusDescription = "You do not have permission to perform this action";

                }
                else
                {
                    filterContext.Result = new HttpStatusCodeResult(403, "Forbidden");
                }
            }

        }

        public bool HandlePermission(int i)
        {
            if (i == 0)
            {
                HasRights = false;
                return false;
            }
            else
            {
                HasRights = true;
                return true;

            }
        }

        //private bool HasPermission(IEnumerable<Permissions> rights, System.Web.HttpContextBase context)
        //{
        //    foreach (var permission in rights)
        //    {
        //        switch (permission)
        //        {
        //            case Permissions.View:
        //                {
        //                    var readAccess = SafeCastSessionProperty(context.Session["ReadAccess"]);

        //                    if (readAccess == hasAccess)
        //                    {
        //                        return true;
                                
        //                    }
        //                    return false;
        //                }
        //            case Permissions.Add:
        //                {
        //                    var writeAccess = SafeCastSessionProperty(context.Session["WriteAccess"]);

        //                    if (writeAccess == hasAccess)
        //                    {
        //                        return true;
        //                    }
        //                    return false;
        //                }
        //            case Permissions.Delete:
        //                {
        //                    var deleteAccess = SafeCastSessionProperty(context.Session["DeleteAccess"]);

        //                    if (deleteAccess == hasAccess)
        //                    {
        //                        return true;
        //                    }
        //                    return false;
        //                }
        //            case Permissions.Edit:
        //                {
        //                    var editAccess = SafeCastSessionProperty(context.Session["EditAccess"]);

        //                    if (editAccess == hasAccess)
        //                    {
        //                        return true;
        //                    }
        //                    return false;
        //                }
                   
                   
        //            default:
        //                break;
        //        }
        //    }

        //    return false;

        //}

        public UserList USER
        {
            get
            {
                var user = SessionHandler.GetSessionObject("USER");

                if (user.IsNotNull())
                {
                    return user as UserList;
                }

                return null;
            }

        }

        public int SafeCastSessionProperty(string val)
        {
            return int.Parse(SessionHandler.GetSessionContext(val));
        }
    }
}
