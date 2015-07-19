using Aamps.Domain.Models;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Repository.Implementations
{
    public class UserRepository : BaseRepository<UserList>, IUserRepository
    {

        public UserRepository(AampsContext context)
            : base(context)
        {

        }

        public UserList GetUserbyId(int identity)
        {
            AampsContext _dbContext = new AampsContext();
            var user = (from x in _dbContext.UserLists
                           where x.UserListID == identity
                           select x).FirstOrDefault();

            _dbContext.Entry(user).Reference(x => x.UserGroup).Load();
            _dbContext.Entry(user).Reference(x => x.UserType).Load();
            _dbContext.Entry(user).Collection(x => x.UserRights).Load();

            return user;
        }

        public UserList GetUserByUsername(string username)
        {
            try
            {
                AampsContext _dbContext = new AampsContext();

               var user = _dbContext.UserLists
                    .Where(x => x.UserListEmail == username)
                    .FirstOrDefault();

               return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserList> GetDevelopmentAgents(int company)
        {
            try
            {
                AampsContext _dbContext = new AampsContext();
                var agents = _dbContext.UserLists
                     .Where(x => x.CompanyID == company)
                     .ToList();

                return agents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
