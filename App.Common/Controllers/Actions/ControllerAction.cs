using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace App.Common.Controllers.Actions
{
    public abstract class ControllerAction : IControllerAction 
    {
        #region Properties

        public object Property { get; set; } 

        protected virtual bool AutoValidate
        {
            get
            {
                return true;
            }
        }

        protected object Context { get; private set; }

        public bool AutoBind { get; set; }

        public bool ExecuteAction { get; set; }

        public IList<IMessage> ActionMessages { get; private set; }

        #endregion

        #region Constructors
        public ControllerAction(object query)
        {

        }
        public ControllerAction()
        {

        }
        #endregion Constructors

        #region Virtual Methods
        public virtual void OnLoadModel()
        {
             
        }

        public virtual void OnBindModel()
        {

        }

        public virtual void OnHydrateModel()
        {

        }

        public virtual object OnExecute()
        {
            return this;
        }
       #endregion Virtual Methods
    }
}
