using AAMPS.Clients.AampService;
using AAMPS.Clients.Security;
using App.Common.Exceptions;
using App.Common.Security;
using App.Extentions;
using System;
using System.Collections;
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

        private string formUrl = string.Empty;
        private List<AampService.UserRight> UserPermissions;

        public AAMPS.Clients.AampService.AampServiceClient _serviceProvider = new AAMPS.Clients.AampService.AampServiceClient();

        public AampsAuthorize(params object[] permissions)
        {
            UserPermissions = new List<UserRight>();

            if (permissions.Any(r => r.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("permissions");

            this._permissions = permissions[0].ToString().Split(',')
                .Select(flag => (Permissions)Enum.Parse(typeof(Permissions), flag))
                .ToList();

        }
        public AampsAuthorize()
        {
            UserPermissions = new List<UserRight>();
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

                    formUrl = GetAreaContext();

                    foreach (var permisssion in _permissions)
                    {
                        var _currentPermission = permisssion;

                        bool hasPermission = false;

                        UserPermissions = GetUserPermissions;

                        if(UserPermissions.HasItems())
                        {
                            foreach (var right in UserPermissions)
                            {
                                var url = _serviceProvider.GetFormPermissions(right.FormReportID).FormReportDescription;

                                if(url == formUrl)
                                {
                                    hasPermission = CheckUserRights(right, _currentPermission);
                                    return HandlePermission(hasPermission);
                                }
                            }
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

        private bool CheckUserRights(UserRight right, Permissions permission)
        {
           if(permission == Permissions.View)
           {
               return right.UserRightView;
           }

           if (permission == Permissions.Add)
           {
               return right.UserRightAdd;
           }

           if (permission == Permissions.Edit)
           {
               return right.UserRightEdit;
           }

           if (permission == Permissions.Delete)
           {
               return right.UserRightDelete;
           }
           return false;
        }

        private string GetAreaContext()
        {
            var action = string.Empty;
            var controller = string.Empty;
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
            if (routeValues.IsNotNull())
            {
                if (routeValues.ContainsKey("action"))
                {
                    action = routeValues["action"].ToString();
                }
                if (routeValues.ContainsKey("controller"))
                {
                    controller = routeValues["controller"].ToString();
                }
            }

            return "/{0}/{1}".FormatInvariantCulture(controller, action);
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
                    filterContext.Result = new RedirectResult("~/Error/Forbidden", true);
                }
                
            }

        }

        public bool HandlePermission(bool status)
        {
            if (!status)
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

        public List<AampService.UserRight> GetUserPermissions
        {
            get
            {
                var user_rights = SessionHandler.GetSessionObject("USER_RIGHTS");
                if (user_rights.IsNotNull())
                {
                    var result = ((IEnumerable)user_rights).Cast<AampService.UserRight>().ToList();
                    return result;  
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
