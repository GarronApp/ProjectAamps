using Aamps.Domain.Models;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Repository.Implementations
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {

        public CompanyRepository(AampsContext context)
            : base(context)
        {

        }

        public Company GetCompanyById(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Companies
                           where x.CompanyID == id
                           select x).FirstOrDefault();
            return results;
        }

        public List<Company> GetAllCompanies()
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Companies
                           select x).ToList();

            return results;
        }

        public List<Company> GetCompaniesByGroup(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Companies
                           where x.UserGroupID == id
                           select x).ToList();

            return results;
        }

    }
}
