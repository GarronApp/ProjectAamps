using Aamps.Domain.Models;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Repository.Implementations
{
    public class PurchaserRepository : BaseRepository<Purchaser>, IPurchaserRepository
    {

        public PurchaserRepository(AampsContext context)
            : base(context)
        {

        }

        public Purchaser GetPurchaserById(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Purchasers
                           where x.PurchaserID == id
                           select x).FirstOrDefault();
            return results;
        }

        public List<EntityType> GetPurchaserEntityTypes()
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.EntityTypes
                           select x).ToList();

            return results;
        }

    }
}
