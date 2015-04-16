using Aamps.Domain.Models;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Repository.Implementations
{
    public class SalesRepository : BaseRepository<Sale>, ISalesRepository
    {
       
        public SalesRepository(AampsContext context)
            : base(context)
        {

        }

        public List<Sale> GetAllSales()
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Sales
                           select x).ToList();

            return results;
        }

        public Sale GetSaleById(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Sales
                           where x.SaleID == id
                           select x).FirstOrDefault();

            return results;
        }

        public Sale GetSaleByUnitId(int id)
        {
            try
            {
                AampsContext _dbContext = new AampsContext();
                var results = (from x in _dbContext.Sales
                               where x.UnitID == id
                               select x).FirstOrDefault();

                _dbContext.Entry(results).Reference(s => s.Unit).Load();
                _dbContext.Entry(results).Reference(s => s.Individual).Load();
                

                return results;
            }
            catch (Exception ex)
            {
                App.Common.Exceptions.ExceptionHandler.HandleException(ex);
                throw ex;
            }
        }

         public void SaveUpdateReservation(Sale sale)
         {
             try
             {
                 AampsContext _dbContext = new AampsContext();
                 _dbContext.Sales.Attach(sale);

             }
             catch (DbUpdateConcurrencyException dbcx)
             {
                 App.Common.Exceptions.ExceptionHandler.HandleException(dbcx);
                 throw dbcx;
             }
             catch (Exception ex)
             {
                 App.Common.Exceptions.ExceptionHandler.HandleException(ex);
                 throw ex;
             }
           
        }


        public List<Company> GetCompanies()
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Companies
                           select x).ToList();

            return results;
        }

        public Company GetCompanyByUserGroupId(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Companies
                           where x.UserGroupID == id
                           select x).FirstOrDefault();

            return results;
        }


    }
}
