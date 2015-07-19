using AAMPS.Clients.AampService;
using AAMPS.Clients.Queries.Sales;
using AAMPS.Clients.ViewModels.Individual;
using AAMPS.Clients.ViewModels.Purchaser;
using App.Common.Controllers.Actions;
using App.Common.Security;
using App.Extentions;
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

        public bool DuplicateIndividual { get; set; }

        public IndividualViewModel IndividualViewModel { get; set; }

        public List<Individual> DuplicationIndividuals { get; set; }

        #endregion Properties

        #region Constructors
        public SaveIndividual()
        {

        }
        public SaveIndividual(IndividualViewModel _newIndividual)
            : base(_newIndividual)
        {
            IndividualViewModel = _newIndividual;
            OnBindModel();
        }

        #endregion Constructors

        #region Virtual Methods
        public override void OnBindModel()
        {
            IsNewIndividual = IndividualViewModel.IsNewIdentity;
            DuplicateIndividual = IndividualViewModel.DuplicateIndividual;

            if (IsNewIndividual)
                OnExecute();
        }

        public override object OnExecute()
        {
            //DUPLICATION SECTION TO BE COMPLETED*
            //var records = ValidateIndividual(IndividualViewModel.IndividualSurname, IndividualViewModel.IndividualContactCell, IndividualViewModel.IndividualEmail);

            //if (records.Count > 0 && DuplicateIndividual)
            //{
            //    DuplicationIndividuals = new List<Individual>();
            //    return DuplicationIndividuals = records.ToList();
            //}

            if (IndividualViewModel.IsNewIndividual == 1)
            {
                var _individual = new Individual();
                MapIndividual(_individual);

                var result = new AampServiceClient().SaveIndividual(_individual);

                if(result.IsNotNull())
                {
                    SessionHandler.SessionContext("IndividualInfo", result);
                }

                _individual.IndividualID = result.IndividualID;
                IndividualViewModel.IndividualID = result.IndividualID;
                IndividualViewModel.PreferedContactMethodID = _individual.PreferedContactMethodID;

                return _individual;
            }

            if (IndividualViewModel.IsNewIndividual == 0)
            {
                var _individual = new AampServiceClient().GetIndividualById(IndividualViewModel.IndividualID);

                if (_individual != null)
                {
                    MapIndividual(_individual);

                    var result = new AampServiceClient().UpdateIndividual(_individual);

                    _individual.IndividualID = result.IndividualID;
                    IndividualViewModel.IndividualID = result.IndividualID;
                    IndividualViewModel.PreferedContactMethodID = _individual.PreferedContactMethodID;

                    return _individual;
                }
            }

            return null;

        }

        private List<AampService.Individual> ValidateIndividual(string surname, string cellphone, string email)
        {
            return new AampServiceClient().ValidateIndividual(IndividualViewModel.IndividualSurname, IndividualViewModel.IndividualContactCell, IndividualViewModel.IndividualEmail).ToList();
        }

        #endregion Virtual Methods

        #region Private Methods

        private void MapIndividual(Individual _individual)
        {
            _individual.IndividualName = IndividualViewModel.IndividualName;
            _individual.IndividualSurname = IndividualViewModel.IndividualSurname;
            _individual.IndividualContactCell = IndividualViewModel.IndividualContactCell;
            _individual.IndividualContactHome = IndividualViewModel.IndividualContactHome;
            _individual.IndividualContactWork = IndividualViewModel.IndividualContactWork;
            _individual.IndividualEmail = IndividualViewModel.IndividualEmail;
            var contactMethod = IndividualViewModel.PreferedContactMethodID.ToString();

            SetPreferedMethod(contactMethod, _individual);
        }

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
