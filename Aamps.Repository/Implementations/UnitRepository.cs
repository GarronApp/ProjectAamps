﻿using Aamps.Domain.Models;
using Aamps.Domain.Queries.Units;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Repository.Implementations
{
    public class UnitRepository : BaseRepository<Unit>, IUnitRepository
    {

        public UnitRepository(AampsContext context)
            : base(context)
        {

        }

        public List<Unit> GetAllUnits()
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Units
                           select x).ToList();

            return results;
        }

        public List<Unit> GetAllAvailableUnits(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Units
                           where x.UnitStatusID == id
                           select x).ToList();

            return results;
        }

        public List<Unit> GetAllUnAvailableUnits(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Units
                           where x.UnitStatusID != id
                           select x).ToList();

            return results;
        }

        public List<Unit> GetUnitsByDevelopment(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Units
                           where x.DevelopmentID == id
                           select x).ToList();

            return results;
        }

        public Unit GetUnitById(int id)
        {
            try
            {
                AampsContext _dbContext = new AampsContext();
                var results = (from x in _dbContext.Units
                               where x.UnitID == id
                               select x).FirstOrDefault();

                //_dbContext.Entry(results).Reference(s => s.Development).Load();

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Unit GetUnitByUnitBlock(string block)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Units
                           where x.UnitBlock == block
                           select x).FirstOrDefault();

            return results;
        }

        public Unit GetUnitByAddedUser(int user)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Units
                           where x.UnitAddedByUser == user
                           select x).FirstOrDefault();

            return results;
        }

        public Unit GetUnitByAgentId(int agent)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Units
                           where x.UnitAgentID == agent
                           select x).FirstOrDefault();

            return results;
        }

        public List<Unit> GetUnitByDevelopmentId(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.Units
                           where x.DevelopmentID == id
                           select x).ToList();

            return results;
        }

        public UnitStatus GetUnitStatusById(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.UnitStatus
                           where x.UnitStatusID == id
                           select x).FirstOrDefault();

            return results;
        }

        public int GetTotalPendingUnits(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.UnitStatus
                           where x.UnitStatusID == id &&
                           x.UnitStatusDescription == "Pending"
                           select x).Count();

            return results;
        }

        public int GetTotalReservedUnits(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.UnitStatus
                           where x.UnitStatusID == id &&
                           x.UnitStatusDescription == "Reserved"
                           select x).Count();

            return results;
        }

        public int GetTotalSoldUnits(int id)
        {
            AampsContext _dbContext = new AampsContext();
            var results = (from x in _dbContext.UnitStatus
                           where x.UnitStatusID == id &&
                           x.UnitStatusDescription == "Sold"
                           select x).Count();

            return results;
        }

        public List<Aamps.Domain.Models.Unit> GetRelevantAvailableUnits(SelectRelevantAvailableUnitQuery SelectRelevantAvailableUnitQuery)
        {
            SqlParameter[] query = 
                {
                   new SqlParameter() { ParameterName = "UserListID", Value = SelectRelevantAvailableUnitQuery.UserListID },
                   new SqlParameter() { ParameterName = "UserTypeID", Value = SelectRelevantAvailableUnitQuery.UserTypeID },
                   new SqlParameter() { ParameterName = "DevelopmentID", Value = SelectRelevantAvailableUnitQuery.DevelopmentID },
                   new SqlParameter() { ParameterName = "CompanyID", Value = SelectRelevantAvailableUnitQuery.CompanyID }
                   
                };

            using (var dc = new AampsContext())
            {
                var result = dc.Database.SqlQuery<Aamps.Domain.Models.Unit>("exec dbo.csp_Select_RelevantAvailableUnits @UserListID,@UserTypeID,@DevelopmentID,@CompanyID", query);
                return result.ToList();
            }
        }

        public List<Aamps.Domain.Models.Unit> GetRelevantUnits(SelectRelevantUnitsQuery SelectRelevantUnitsQuery)
        {
            SqlParameter[] query = 
                {
                   new SqlParameter() { ParameterName = "UserListID", Value = SelectRelevantUnitsQuery.UserListID},
                   new SqlParameter() { ParameterName = "UserTypeID", Value = SelectRelevantUnitsQuery.UserTypeID },
                   new SqlParameter() { ParameterName = "DevelopmentID", Value = SelectRelevantUnitsQuery.DevelopmentID },
                };

            using (var dc = new AampsContext())
            {
                var result = dc.Database.SqlQuery<Aamps.Domain.Models.Unit>("exec dbo.csp_Select_RelevantUnits @UserListID,@UserTypeID,@DevelopmentID", query);
                return result.ToList();
            }
        }

        public List<Aamps.Domain.Models.Unit> GetRelevantSummaryUnits(SelectRelevantSummaryUnitQuery SelectRelevantSummaryUnitQuery)
        {
            SqlParameter[] query = 
                {
                   new SqlParameter() { ParameterName = "DevelopmentID", Value = SelectRelevantSummaryUnitQuery.DevelopmentID },
                   new SqlParameter() { ParameterName = "UserListID", Value = (object)SelectRelevantSummaryUnitQuery.UserListID ?? DBNull.Value }
                 
                };

            using (var dc = new AampsContext())
            {
                var result = dc.Database.SqlQuery<Aamps.Domain.Models.Unit>("exec dbo.csp_Select_RelevantUnitsforDevSummary @DevelopmentID,@UserListID", query);
                return result.ToList();
            }
        }


    }
}
