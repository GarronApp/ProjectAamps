﻿using ProjectAamps.Clients.Security;
using System.Web;
using System.Web.Mvc;

namespace AAMPS.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
