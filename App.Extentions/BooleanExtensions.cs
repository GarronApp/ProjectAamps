using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Extentions
{
    public static class BooleanExtensions
    {
        public static string ToString(this bool value, string trueValue, string falseValue)
        {
            return value ? trueValue : falseValue;
        }

        public static string AsStringBool(this bool? value, string trueValue, string falseValue)
        {
            if (value.HasValue)
            {
                return value.Value.ToString(trueValue, falseValue);
            }
            return string.Empty;
        }

        public static int BoolToInt(this bool? value)
        {
            if(value.HasValue)
            {
                if (value == true)
                    return 1;
                else
                    return 0;
            }
            return 0;
        }
    }
}
