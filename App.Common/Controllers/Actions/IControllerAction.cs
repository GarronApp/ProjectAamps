using System;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.Common.Controllers.Actions
{
    public interface IControllerAction 
    {
        #region Virtual Methods
        void OnLoadModel();

        void OnBindModel();

        void OnHydrateModel();

        object OnExecute();

        #endregion Virtual Methods

    }
}
