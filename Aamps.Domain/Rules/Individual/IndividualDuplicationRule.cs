using Aamps.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Rules.Individual
{

    public class IndividualDuplicationRule : RuleBaseProvider, IndividualRules
    {
        public bool checkBioGraphicInformation = false;

        public bool checkContactInformation = false;

        public bool ValidateUniqueIndividual(string lastname, string cellphone, string email)
        {
            var propertyLastName = _context.Individuals.Where(x => x.IndividualSurname == lastname).Count();

            if(propertyLastName > 0)
            {
                checkBioGraphicInformation = true;
            }

            var propertiesCellAndEmail = _context.Individuals.Where(x => x.IndividualContactCell == cellphone && x.IndividualEmail == email).Count();

            if(propertiesCellAndEmail > 0)
            {
                checkContactInformation = true;
            }

            return checkBioGraphicInformation && checkContactInformation;

        }


        public List<Models.Individual> GetDuplicationIndividuals(string lastname, string cellphone, string email)
        {
            var list = new List<Models.Individual>();
            if(ValidateUniqueIndividual(lastname,cellphone,email))
            {
                return _context.Individuals.Where(x => x.IndividualSurname == lastname && x.IndividualContactCell == cellphone && x.IndividualEmail == email).ToList();
            }

            return list;
        }

    }
}
