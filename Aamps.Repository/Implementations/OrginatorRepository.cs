using Aamps.Domain.Models;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Repository.Implementations
{
    public class OrginatorRepository : BaseRepository<OriginatorTr>, IOriginatorRepository
    {

        public OrginatorRepository(AampsContext context)
            : base(context)
        {

        }

        public void UpdateOriginatorTr(OriginatorTr originatorTr)
         {
             try
             {
                 AampsContext _dbContext = new AampsContext();
                 _dbContext.OriginatorTrs.Attach(originatorTr);
                 _dbContext.Entry(originatorTr).State = EntityState.Modified;
                 _dbContext.SaveChanges();

             }
             catch (Exception ex)
             {
                 App.Common.Exceptions.ExceptionHandler.HandleException(ex);
                 throw ex;
             }
           
        }

        public void AddOriginatorTr(OriginatorTr originatorTr)
        {
            try
            {
                AampsContext _dbContext = new AampsContext();
                _dbContext.OriginatorTrs.Add(originatorTr);

            }
            catch (Exception ex)
            {
                App.Common.Exceptions.ExceptionHandler.HandleException(ex);
                throw ex;
            }

        }

    }
}
