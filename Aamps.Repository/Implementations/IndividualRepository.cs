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

      

    }
}
