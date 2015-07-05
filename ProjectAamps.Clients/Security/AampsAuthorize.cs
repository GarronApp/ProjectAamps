using AAMPS.Clients.AampService;
using AAMPS.Clients.Security;
using App.Common.Exceptions;
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
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace AAMPS.Clients.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AampsAuthorize : AuthorizeAttribute
    {
        private readonly List<Permissions> _permissions;

        private bool checkPermissions = false;

        private bool HasRights = false;

        public AAMPS.Clients.AampService.AampServiceClient _serviceProvider = new AAMPS.Clients.AampService.AampServiceClient();

        public AampsAuthorize(params object[] permissions)
        {
            if (permissions.Any(r => r.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("permissions");

            this._permissions = permissions[0].ToString().Split(',')
                .Select(flag => (Permissions)Enum.Parse(typeof(Permissions), flag))
                .ToList();

        }
        public AampsAuthorize()
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
                                hasPermission = SessionHandler.CastSessionToInt("USER_RIGHT_VIEW");
                                return HandlePermission(hasPermission);
                            }
                            if (permisssion == Permissions.Add)
                            {
                                hasPermission = SessionHandler.CastSessionToInt("USER_RIGHT_ADD");
                                return HandlePermission(hasPermission);
                            }
                            if (permisssion == Permissions.Edit)
                            {
                                hasPermission = SessionHandler.CastSessionToInt("USER_RIGHT_EDIT");
                                return HandlePermission(hasPermission);
                            }
                            if (permisssion == Permissions.Delete)
                            {
                                hasPermission = SessionHandler.CastSessionToInt("USER_RIGHT_DELETE");
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
                ExceptionHandler.HandleException(ex);
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
                if(filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new HttpStatusCodeResult(403, string.Empty);
                }
                else
                {
                    filterContext.Result = new HttpStatusCodeResult(403, string.Empty);
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
