using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml;
using System.Web;


namespace App.Common.Exceptions
{
    public static class ExceptionHandler
    {
        public static void HandleException(Exception exc)
        {
            try
            {
                string exceptionLogpath = HttpContext.Current.Server.MapPath("~/") + ConfigurationManager.AppSettings["ExceptionLog"];
                StreamWriter ExceptionLog = new StreamWriter(exceptionLogpath, true);
                ExceptionLog.WriteLine("-----------------------= Start Exception =--------------------------");
                ExceptionLog.WriteLine(DateTime.Now);
                ExceptionLog.WriteLine();
                ExceptionLog.WriteLine(exc.Message.ToString());
                ExceptionLog.WriteLine(exc.StackTrace);
                ExceptionLog.WriteLine("----= Inner Exception Exception =----");
                ExceptionLog.WriteLine(exc.InnerException);
                ExceptionLog.WriteLine("------------------------= End Exception =---------------------------");
                ExceptionLog.WriteLine("");
                ExceptionLog.WriteLine("");
                ExceptionLog.Close();
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

    }
}
