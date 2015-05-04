using Aamps.Domain.Models;
using Aamps.Repository.Implementations;
using System.Collections.Generic;

namespace Aamps.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AampService : IAampService
    {
        AampsContext _dbContext = new AampsContext();
        UnitRepository _unitRepo;
        SalesRepository _salesRepo;
        DevelopmentRepository _devRepo;
        IndividualRepository _personRepo;
        UserRepository _userRepo;

        public AampService()
        {
        }

        public AampService(AampsContext context)
        {
            _dbContext = context;
            _dbContext.Configuration.LazyLoadingEnabled = false;
            _dbContext.Configuration.ProxyCreationEnabled = false;
        }

        public List<Unit> GetAllUnits()
        {
            _unitRepo = new UnitRepository(_dbContext);
            var results = _unitRepo.GetAllUnits();

            return results;
        }

        public List<Unit> GetAllAvailableUnits(int id)
        {
            _unitRepo = new UnitRepository(_dbContext);
            var results = _unitRepo.GetAllAvailableUnits(id);

            return results;
        }

        public List<Unit> GetAllUnAvailableUnits(int id)
        {
            _unitRepo = new UnitRepository(_dbContext);
            var results = _unitRepo.GetAllUnAvailableUnits(id);

            return results;
        }

        public Unit GetUnitById(int id)
        {
            try
            {
                _unitRepo = new UnitRepository(_dbContext);
                var results = _unitRepo.GetUnitById(id);

                return results;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public Unit GetUnitByUnitBlock(string block)
        {
            _unitRepo = new UnitRepository(_dbContext);
            var results = _unitRepo.GetUnitByUnitBlock(block);

            return results;
        }

        public Unit GetUnitByAddedUser(int user)
        {
            _unitRepo = new UnitRepository(_dbContext);
            var results = _unitRepo.GetUnitByAddedUser(user);

            return results;
        }

        public Unit GetUnitByAgentId(int agent)
        {
            _unitRepo = new UnitRepository(_dbContext);
            var results = _unitRepo.GetUnitByAgentId(agent);

            return results;
        }

        public List<Unit> GetUnitByDevelopmentId(int id)
        {
            _unitRepo = new UnitRepository(_dbContext);
            var results = _unitRepo.GetUnitByDevelopmentId(id);
            return results;
        }

        public void UpdateUnit(Unit unit)
        {
            _unitRepo = new UnitRepository(_dbContext);
            _unitRepo.Update(unit);
        }

        public List<Sale> GetAllSales()
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetAllSales();
            return results;
        }

        public Sale GetSaleById(int id)
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetSaleById(id);
            return results;
        }

        public Sale GetSaleByUnitId(int id)
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetSaleByUnitId(id);
            return results;
        }

         public void SaveUpdateReservation(Sale reservation)
         {
            _salesRepo = new SalesRepository(_dbContext);
            _salesRepo.Update(reservation);
        }

        public void SavePerson(Individual person)
        {
            _personRepo = new IndividualRepository(_dbContext);
            _personRepo.Add(person);
        }

        public UnitStatus GetUnitStatusById(int id)
        {
            _unitRepo = new UnitRepository(_dbContext);
            var results = _unitRepo.GetUnitStatusById(id);

            return results;
        }

        public List<Company> GetCompanies()
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetCompanies();

            return results;
        }

        public Company GetCompanyByUserGroupId(int id)
        {
             _salesRepo = new SalesRepository(_dbContext);
             var results = _salesRepo.GetCompanyByUserGroupId(id);

            return results;
        }

        public List<Development> GetAllDevelopments()
        {
            _devRepo = new DevelopmentRepository(_dbContext);
            var results = _devRepo.GetAllDevelopments();

            return results;
        }

        public Development GetDevelopmentById(int id)
        {
            _devRepo = new DevelopmentRepository(_dbContext);
            var results = _devRepo.GetDevelopmentById(id);

            return results;
        }

        public Estate GetEstateByDevelopment(int id)
        {
            _devRepo = new DevelopmentRepository(_dbContext);
            var results = _devRepo.GetEstateByDevelopment(id);

            return results;
       }

        public UserList GetUser(int identity)
        {
            _userRepo = new UserRepository(_dbContext);
            var user = _userRepo.GetUserbyId(identity);

            return user;
        }

        public UserList GetCurrentUser(string username)
        {
            _userRepo = new UserRepository(_dbContext);
            var user = _userRepo.GetUserByUsername(username);

            return user;
        }


    }
}
