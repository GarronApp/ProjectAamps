using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Rules.Individual
{
    [ServiceContract]
    public interface IndividualRules
    {
        [OperationContract]
        bool ValidateUniqueIndividual(string lastname, string cellphone, string email);

        [OperationContract]
        List<Aamps.Domain.Models.Individual> GetDuplicationIndividuals(string lastname, string cellphone, string email);
    }
}
