using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Extentions
{
    /// <summary>
    /// A helper class for object validation
    /// </summary>
    public static class Invariant
    {
        /// <summary>
        /// Checks the object argument is not null and throws an exception if it is
        /// </summary>
        /// <param name="argument">The object to validate</param>
        /// <param name="argumentName">The argument parameter name</param>
        public static void ArgumentNotNull(object argument, Func<string> argumentName)
        {
            if (argument == null)
            {
                throw new InvariantException(argumentName());
            }
        }

        /// <summary>
        /// Verfies a string is not null or empty and will throw an Exception if it is
        /// </summary>
        /// <param name="argument">The string to validate</param>
        /// <param name="argumentName">The argument parameter name</param>
        public static void ArgumentNotEmpty(string argument, Func<string> argumentName)
        {
            if (argument.IsNullOrEmpty())
            {
                throw new InvariantException("Empty argument: " + argumentName());
            }
        }

        /// <summary>
        /// Verfies a value is not null.
        /// </summary>
        public static void IsNotNull(object value, Func<string> error)
        {
            if (value.IsNull())
            {
                throw new InvariantException(error());
            }
        }

        /// <summary>
        /// Verfies a value is not null.
        /// </summary>
        public static void IsNull(object value, Func<string> error)
        {
            if (value.IsNotNull())
            {
                throw new InvariantException(error());
            }
        }

        /// <summary>
        /// Verfies a bool value is true. If false an exception is thrown
        /// </summary>
        /// <param name="test">The boolean to validate</param>
        public static void IsTrue(bool test, Func<string> error)
        {
            if (!test)
            {
                throw new InvariantException(error());
            }
        }

        /// <summary>
        /// Verfies a bool value is false. If true an exception is thrown
        /// </summary>
        /// <param name="test">The boolean to validate</param>
        public static void IsFalse(bool test, Func<string> error)
        {
            if (test)
            {
                throw new InvariantException(error());
            }
        }

        /// <summary>
        /// Verfies a bool value is false. If true an exception is thrown
        /// </summary>
        /// <param name="test">The boolean to validate</param>
        public static void Fail(string error)
        {
            throw new InvariantException(error);
        }
    }
}
