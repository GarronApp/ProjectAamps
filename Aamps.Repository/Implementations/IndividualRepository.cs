using Aamps.Domain.Models;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Repository.Implementations
{
    public class IndividualRepository : BaseRepository<Individual>, IIndividualRepository
    {

        public IndividualRepository(AampsContext context)
            : base(context)
        {

        }

        public Individual GetIndividualById(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Individuals
                           where x.IndividualID == id
                           select x).FirstOrDefault();
            return results;
        }


        public PreferedContactMethod GetPreferedContactMethodById(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.PreferedContactMethods
                           where x.PreferedContactMethodID == id
                           select x).FirstOrDefault();
            return results;
        }

        public List<PreferedContactMethod> GetAllPreferedContactMethods()
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.PreferedContactMethods
                           select x).ToList();
            return results;
        }


      

    }
}
