using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAMPS.Web.Models.ViewModels.Mappers
{
    public abstract class Mapper<T>
    {

        #region Virtual Methods

        public abstract T Map();

        #endregion
    }
}