﻿using Aamps.Domain.Models;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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

        public SaleActiveStatus GetSaleActiveStatus(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.SaleActiveStatus
                           where x.SaleActiveStatusID == id
                           select x).FirstOrDefault();

            return results;
        }

        public List<SaleType> GetSaleTypes()
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.SaleTypes
                           select x).ToList();

            return results;
        }

        public List<SaleDepositProof> GetDepositTypes()
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.SaleDepositProofs
                           select x).ToList();

            return results;
        }

        public List<OriginatorTr> GetOriginatorBySalesId(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.OriginatorTrs
                           where x.SaleID == id
                           select x).ToList();
            return results;
        }

        public OriginatorTr GetOriginatorById(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.OriginatorTrs
                           where x.OriginatorTrID == id
                           select x).FirstOrDefault();
            return results;
        }

        public Bank GetBankById(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Banks
                           where x.BankID == id
                           select x).FirstOrDefault();

            return results;
        }

        public List<Bank> GetAllBanks()
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Banks
                           select x).ToList();

            return results;
        }

        public MOStatus GetMOStatusById(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.MOStatus
                           where x.MOStatusID == id
                           select x).FirstOrDefault();
            return results;
        }

        public List<Aamps.Domain.Queries.Reports.Sales.SalesReportQuery> GetSalesReport(int developmentID)
        {
            var development = new SqlParameter
            {
                ParameterName = "DevelopmentID",
                Value = developmentID
            };

            using (var dc = new AampsContext())
            {

                var result = dc.Database.SqlQuery<Aamps.Domain.Queries.Reports.Sales.SalesReportQuery>("exec dbo.csp_Report_Sales @DevelopmentID", development);
                return result.ToList();
            }
        }

        public List<Aamps.Domain.Queries.Reports.Bonds.BondsReportQuery> GetBondsReport(int developmentID)
        {
            var development = new SqlParameter
            {
                ParameterName = "DevelopmentID",
                Value = developmentID
            };

            using (var dc = new AampsContext())
            {
                var result = dc.Database.SqlQuery<Aamps.Domain.Queries.Reports.Bonds.BondsReportQuery>("exec dbo.csp_Report_Bonds @DevelopmentID", development);
                return result.ToList();
            }
        }

        public List<MOStatus> GetAllMOStatus()
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.MOStatus
                           select x).ToList();
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
                _dbContext.Entry(results).Reference(s => s.Purchaser).Load();
                

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

        public void AddSale(Sale sale)
        {
             try
             {
                 AampsContext _dbContext = new AampsContext();
                 _dbContext.Sales.Add(sale);

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


    }
}
