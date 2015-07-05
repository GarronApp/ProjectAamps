using Aamps.Domain.Models;
using Aamps.Domain.Queries.Developments;
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

        public List<Aamps.Domain.Queries.Developments.SelectRelevantDevelopmentResult> GetRelevantDevelopments(SelectRelevantDevelopmentQuery SelectRelevantDevelopmentQuery)
        {
            SqlParameter[] query = 
                {
                   new SqlParameter() { ParameterName = "UserListID", Value = SelectRelevantDevelopmentQuery.UserListID },
                   new SqlParameter() { ParameterName = "UserGroupID", Value = SelectRelevantDevelopmentQuery.UserGroupID },
                   new SqlParameter() { ParameterName = "CompanyID", Value = SelectRelevantDevelopmentQuery.CompanyID },
                   new SqlParameter() { ParameterName = "UserTypeID", Value = SelectRelevantDevelopmentQuery.UserTypeID }
                };

         using (var dc = new AampsContext())
            {
                var result = dc.Database.SqlQuery<Aamps.Domain.Queries.Developments.SelectRelevantDevelopmentResult>("exec dbo.csp_Select_RelevantDevelopments @UserListID,@UserGroupID,@CompanyID,@UserTypeID", query);
                return result.ToList();
            }
        }

    }
}
