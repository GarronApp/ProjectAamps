using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.Mappers
{
    public abstract class Mapper<T>
    {
        public Mapper()
        {
            
        }
        #region Virtual Methods

        public abstract T Map();

        #endregion
    }
}
