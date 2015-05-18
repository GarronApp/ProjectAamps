using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Reporting
{
    public static class ReportSettings
    {
        public static string Template1 = System.Configuration.ConfigurationManager.AppSettings["Template"];
        public static string Template2 = System.Configuration.ConfigurationManager.AppSettings["Template"];
        public static string Template3 = System.Configuration.ConfigurationManager.AppSettings["Template"];
    }
}
