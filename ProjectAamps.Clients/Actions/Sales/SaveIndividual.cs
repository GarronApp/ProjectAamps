using AAMPS.Clients.AampService;
using AAMPS.Clients.Queries.Sales;
using AAMPS.Clients.ViewModels.Individual;
using AAMPS.Clients.ViewModels.Purchaser;
using App.Common.Controllers.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.Actions.Sales
{
    public class SaveIndividual : ControllerAction
    {
        #region Properties
        public bool IsNewIndividual { get; set; }

        public IndividualViewModel newIndividualViewModel { get; set; }

        #endregion Properties

        #region Constructors
        public SaveIndividual()
        {

        }
        public SaveIndividual(IndividualViewModel _newIndividual)
            : base(_newIndividual)
        {
            newIndividualViewModel = _newIndividual;
            OnBindModel();
        }

        #endregion Constructors

        #region Virtual Methods
        public override void OnBindModel()
        {
            IsNewIndividual = newIndividualViewModel.IsNewIdentity;

            if (IsNewIndividual)
                OnExecute();
        }

        public override object OnExecute()
        {
            var _individual = new Individual();

            _individual.IndividualName = newIndividualViewModel.IndividualName;
            _individual.IndividualSurname = newIndividualViewModel.IndividualSurname;
            _individual.IndividualContactCell = newIndividualViewModel.IndividualContactCell;
            _individual.IndividualContactHome = newIndividualViewModel.IndividualContactHome;
            _individual.IndividualContactWork = newIndividualViewModel.IndividualContactWork;
            _individual.IndividualEmail = newIndividualViewModel.IndividualEmail;
            var contactMethod = newIndividualViewModel.PreferedContactMethodID.ToString();

            SetPreferedMethod(contactMethod, _individual);

            var result =  new AampServiceClient().SavePerson(_individual);

              _individual.IndividualID = result.IndividualID;
              newIndividualViewModel.IndividualID = result.IndividualID;
              newIndividualViewModel.PreferedContactMethodID = _individual.PreferedContactMethodID;

            return _individual;
        }

        #endregion Virtual Methods

        #region Private Methods
        private void SetPreferedMethod(string contactMethod, Individual individual)
        {
            switch (contactMethod)
            {
                case "0":
                    {
                        individual.PreferedContactMethodID = 1;
                        break;
                    }

                case "1":
                    {
                        individual.PreferedContactMethodID = 4;
                        break;
                    }
                case "2":
                    {
                        individual.PreferedContactMethodID = 2;
                        break;
                    }
                case "3":
                    {
                        individual.PreferedContactMethodID = 3;
                        break;

                    }
                default:
                    break;


            }
        }

        #endregion Private Methods

    }
}
