using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Comparers
{
    public class GenericEqualityComparer<T> : IEqualityComparer<T>
    {
        private Func<T, T, bool> equalsDelegate;
        private Func<T, int> getHashCodeDelegate;

        #region Constructors

        public GenericEqualityComparer(Func<T, T, bool> equalsDelegate, Func<T, int> getHashCodeDelegate)
        {
            this.equalsDelegate = equalsDelegate;
            this.getHashCodeDelegate = getHashCodeDelegate;
        }

        #endregion

        #region IEqualityComparer members

        public bool Equals(T x, T y)
        {
            return equalsDelegate(x, y);
        }

        public int GetHashCode(T obj)
        {
            return getHashCodeDelegate(obj);
        }

        #endregion
    }
}
