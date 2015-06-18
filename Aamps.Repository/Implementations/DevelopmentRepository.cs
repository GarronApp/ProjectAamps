using Aamps.Domain.Models;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Repository.Implementations
{
    public class DevelopmentRepository : BaseRepository<Development>, IDevelopmentRepository
    {

        public DevelopmentRepository(AampsContext context)
            : base(context)
        {

        }

        public List<Development> GetAllDevelopments()
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Developments
                           select x).ToList();

            return results;
        }

        public Development GetDevelopmentById(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Developments
                           where x.DevelopmentID == id
                           select x).FirstOrDefault();

            return results;
        }

        public Estate GetEstateByDevelopment(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Estates
                           where x.EstateID == id
                           select x).FirstOrDefault();

            return results;
        }

        public List<Aamps.Domain.Queries.Developments.SelectRelevantDevelopmentQuery> GetRelevantDevelopments(int userId, int groupId, int companyId, int userTypeId)
        {
            var query = new List<SqlParameterCollection>();
            {
                new SqlParameter() { ParameterName = "UserListID", Value = userId };
                new SqlParameter() { ParameterName = "UserGroupID", Value = groupId };
                new SqlParameter() { ParameterName = "UserCompanyID", Value = companyId };
                new SqlParameter() { ParameterName = "UserTypeID", Value = userTypeId };
            };

            using (var dc = new AampsContext())
            {
                var result = dc.Database.SqlQuery<Aamps.Domain.Queries.Developments.SelectRelevantDevelopmentQuery>("exec dbo.csp_Select_RelevantDevelopments @UserListID @UserGroupID @UserCompanyID @UserTypeID", query);
                return result.ToList();
            }
        }

    }
}
