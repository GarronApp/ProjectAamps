using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Rules
{
    public class RuleBaseProvider
    {
        public Aamps.Domain.Models.AampsContext _context
        {
            get
            {
                return new Models.AampsContext();
            }
        }
    }
}
