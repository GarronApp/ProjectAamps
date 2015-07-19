using Aamps.Domain.Models;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Repository.Implementations
{
    public class UserPermissionRepository : BaseRepository<UserRight>, IUserPermissionRepository
    {
        public UserPermissionRepository(AampsContext context)
            : base(context)
        {

        }

        public List<UserRight> GetUserPermissions(int user)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.UserRights
                           where x.UserListID == user
                           select x).ToList();

            return results;
        }

        public FormReport GetFormPermissions(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.FormReports
                           where x.FormReportID == id
                           select x).FirstOrDefault();

            return results;
        }
    }
}
