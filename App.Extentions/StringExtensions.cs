using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Extentions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Formats this string with the InvariantCulture passing in the specified paramaters
        /// </summary>
        public static string FormatInvariantCulture(this String format, params object[] values)
        {
            return string.Format(CultureInfo.InvariantCulture, format, values);
        }

        /// <summary>
        /// Indicates whether this string is null or empty
        /// </summary>
        public static bool IsNullOrEmpty(this String value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Indicates whether this string is not null or empty
        /// </summary>
        public static bool IsNotNullOrEmpty(this String value)
        {
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Indicates whether this string is null or has whitespace
        /// </summary>
        public static bool IsNullOrWhiteSpace(this String value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Returns the default value if the string is null or empty
        /// </summary>
        public static string OrDefault(this string value, string defaultValue)
        {
            if (value.IsNullOrEmpty())
            {
                return defaultValue;
            }
            return value;
        }

        /// <summary>
        /// Executes the defaultValue only if the value is not set
        /// </summary>
        public static string OrDefaultLazy(this string value, Func<string> defaultValue)
        {
            if (value.IsNullOrEmpty())
            {
                return defaultValue();
            }
            return value;
        }

        /// <summary>
        /// Does a Left operation on this string
        /// </summary>
        public static string Left(this string value, int length)
        {
            if (value.IsNotNullOrEmpty())
            {
                if (value.Length <= length)
                {
                    return value;
                }
                return value.Substring(0, length);
            }
            return string.Empty;
        }

        /// <summary>
        /// Does a Right operation on this string
        /// </summary>
        public static string Right(this string value, int length)
        {
            if (value.IsNotNullOrEmpty())
            {
                if (value.Length <= length)
                {
                    return value;
                }
                return value.Substring(value.Length - length);
            }
            return string.Empty;
        }

        /// <summary>
        /// Returns the string after the value
        /// </summary>
        public static string SubstringAfter(this string source, string value)
        {
            if (source.IsNullOrEmpty())
            {
                return string.Empty;
            }

            if (value.IsNullOrEmpty())
            {
                return source;
            }

            CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            int index = compareInfo.IndexOf(source, value, CompareOptions.OrdinalIgnoreCase);
            if (index < 0)
            {
                //No such substring
                return string.Empty;
            }
            return source.Substring(index + value.Length);
        }

        /// <summary>
        /// Returns the string before the value
        /// </summary>
        public static string SubstringBefore(this string source, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            int index = compareInfo.IndexOf(source, value, CompareOptions.OrdinalIgnoreCase);
            if (index < 0)
            {
                //No such substring
                return string.Empty;
            }
            return source.Substring(0, index);
        }

        public static string ToMD5Checksum(this string value)
        {
            if (value.IsNotNullOrEmpty())
            {
                using (var myMD5 = new MD5CryptoServiceProvider())
                {
                    var data = myMD5.ComputeHash(Encoding.Default.GetBytes(value));
                    var stringBuilder = new StringBuilder();
                    for (var i = 0; i < data.Length; i++)
                    {
                        stringBuilder.Append(data[i].ToString("x2", CultureInfo.CurrentCulture));
                    }
                    return stringBuilder.ToString();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Encrypts the given string using TripleDESCryptoServiceProvider with the provided key
        /// </summary>
        public static string Encrypt(this string value, string key)
        {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = UTF8Encoding.UTF8.GetBytes(key);
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                var encryptor = tdes.CreateEncryptor();
                var valueBytes = UTF8Encoding.UTF8.GetBytes(value);
                var encryptedBlock = encryptor.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
                return Convert.ToBase64String(encryptedBlock, 0, encryptedBlock.Length);
            };
        }

        /// <summary>
        /// Decrypts the given string using TripleDESCryptoServiceProvider with the provided key
        /// </summary>
        public static string Decrypt(this string value, string key)
        {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = UTF8Encoding.UTF8.GetBytes(key);
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                var decryptor = tdes.CreateDecryptor();
                var valueBytes = Convert.FromBase64String(value);
                var decryptedBlock = decryptor.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
                return UTF8Encoding.UTF8.GetString(decryptedBlock);
            }
        }

        /// <summary>
        /// Deserialises the string to the given type is a DataContractSerializer
        /// </summary>
        public static T Deserialise<T>(this string value)
        {
            var result = value.Deserialise(typeof(T));

            if (result.IsNull())
            {
                return default(T);
            }

            return (T)result;
        }

        /// <summary>
        /// Deserialises the string to the given type is a DataContractSerializer
        /// </summary>
        public static object Deserialise(this string value, Type type)
        {
            if (value.IsNotNullOrEmpty())
            {
                try
                {
                    var serializer = DataContractFactory.Create(type);

                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
                    {
                        return serializer.ReadObject(memoryStream);
                    }
                }
                catch
                {
                    return null;
                }
            }

            return null;

        }

        public static T SafeCastDeserialise<T>(this string value)
        {
            if (value.IsNotNullOrEmpty())
            {
                try
                {
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
                    {
                        var serializer = DataContractFactory.Create(typeof(T));
                        return (T)serializer.ReadObject(new SafeCastXmlReader(memoryStream));
                    }
                }
                catch
                {
                    return default(T);
                }
            }

            return default(T);
        }

        /// <summary>
        /// Replaces capital letters with its respective lower case character and adds a space before the character
        /// </summary>
        public static string RemoveCamelCasing(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return string.Empty;
            }

            var words = Regex.Split(value, @"(?<!^)(?=[A-Z])");
            var result = new StringBuilder();

            words.ForEach(w => result.Append("{0} ".FormatInvariantCulture(w.Trim())));

            return result.ToString().Trim();
        }



        /// <summary>
        /// Parses the value and returns a value that is a valid file name
        /// </summary>
        public static string ValidFileName(this string value)
        {
            return Regex.Replace(value, @"[^\w\.-]", " ");
        }

        /// <summary>
        /// Safely converts the value to an integer. Null, empty or error returns zero
        /// </summary>
        public static int? AsInt(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return null;
            }

            var result = 0;
            if (int.TryParse(value, out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Safely converts the value to an integer. Null, empty or error returns zero
        /// </summary>
        public static long? AsLong(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return null;
            }

            long result = 0;
            if (long.TryParse(value, out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Safely converts the value to a Datetime structure. Null, empty or error returns default(DateTime)
        /// </summary>
        public static DateTime? AsDate(this string value, params string[] formats)
        {
            DateTime result;
            foreach (var format in formats)
            {
                if (DateTime.TryParseExact(value, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
                {
                    return result;
                }
            }

            return default(DateTime);
        }


        /// <summary>
        /// Safely converts the value to a float. Null, empty or error returns zero
        /// </summary>
        public static float? AsFloat(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return null;
            }

            var result = 0F;
            if (float.TryParse(value, out result))
            {
                return result;
            }

            return null;
        }

        public static string TrimEnd(this string value, string trimString)
        {
            if (value.IsNullOrEmpty())
            {
                return string.Empty;
            }

            if (value.Trim().EndsWith(trimString, StringComparison.OrdinalIgnoreCase))
            {
                if (value.Length >= trimString.Length)
                {
                    return value.Left(value.Length - trimString.Length);
                }
            }

            return value;
        }

        /// <summary>
        /// Safely appends an additional string value to the given value. No append occrrus for null or empty given value
        /// </summary>
        public static string SafeAppend(this string value, string appendedValue)
        {
            if (value.IsNotNullOrEmpty())
            {
                return value + appendedValue;
            }

            return value;
        }

        /// <summary>
        /// Returns if string is equal to range of values, ignores case
        /// </summary>
        public static bool IsIn(this string value, params string[] values)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }

            foreach (var item in values)
            {
                if (value.Equals(item, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public static string ToUpperFirstLetter(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return string.Empty;
            }

            var letters = value.ToCharArray();
            letters[0] = char.ToUpperInvariant(letters[0]);
            return new string(letters);
        }

        public static string ToTitleCase(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return string.Empty;
            }
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value.ToLower(CultureInfo.InvariantCulture));
        }

        public static string RemoveLineBreaksAndEscapeCharacters(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return string.Empty;
            }

            var patternString = @"\\r\\n|\\n|\\r|\\\n";
            var result = Regex.Replace(value, patternString, "", RegexOptions.IgnoreCase);

            var quoteString = @"\\\""";
            result = Regex.Replace(result, quoteString, @"\\""", RegexOptions.IgnoreCase);

            quoteString = @"[ ]{2,}";
            result = Regex.Replace(result, quoteString, @"\\""", RegexOptions.IgnoreCase);

            quoteString = @"\\{2,}""";
            return Regex.Replace(result, quoteString, @"\\\""", RegexOptions.IgnoreCase);


        }

    }
}
