using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Mappers
{
    public abstract class Mapper<T>
    {
        public Mapper()
        {
            Map();
        }
        #region Virtual Methods

        public abstract T Map();

        #endregion
    }
}
