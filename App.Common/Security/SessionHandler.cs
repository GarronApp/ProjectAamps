using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Common.Security
{
    public static class SessionHandler
    {
        public static void SessionContext(string session, object value)
        {
            if (HttpContext.Current.Session["" + session + ""] != null)
            {
                HttpContext.Current.Session.Remove("" + session + "");
                HttpContext.Current.Session.Add("" + session + "", value);
            }
            else
            {
                HttpContext.Current.Session.Add("" + session + "", value);
            }
        }

        public static string GetSessionContext(string session)
        {
             if (HttpContext.Current.Session["" + session + ""] != null)
             {
                 return HttpContext.Current.Session["" + session + ""].ToString();
             }
             return null;
        }

        public static int CastSessionToInt(object session)
        {
            if (HttpContext.Current.Session["" + session + ""] != null)
            {
                var result = HttpContext.Current.Session["" + session + ""];
                if(result != null)
                {
                    return result.Equals(true) ? 1 : 0;
                }
                
            }
            return 0;
        }

        public static Object GetSessionObject(string session)
        {
            if (HttpContext.Current.Session["" + session + ""] != null)
            {
                return (Object)HttpContext.Current.Session["" + session + ""] as Object;
            }
            return null;
        }
    }
}
