using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Common.Validation
{
    public static class LoginValidationHandler
    {
        public static bool ValidateEmail(string email, string compareEmail)
        {
            bool validEmail = false;
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

            if (Regex.IsMatch(email, pattern))
            {
                if (compareEmail != "")
                {
                    validEmail = email == compareEmail ? true : false;
                }
            }
            return validEmail;
        }

        public static bool ValidatePasswords(string password, string comparepassword)
        {
            if (password != string.Empty && comparepassword != string.Empty)
            {
                return password == comparepassword ? true : false;
            }
            else
            {
                return false;
            }
        }
    }
}
