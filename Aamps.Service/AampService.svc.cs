using Aamps.Domain.Models;
using Aamps.Domain.ValueObjects;
using Aamps.Domain.ViewModels.Reports.Sales;
using Aamps.Repository.Implementations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

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
        PurchaserRepository _purchaserRepo;
        UserRepository _userRepo;
        OrginatorRepository _orginatorRepo;

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

        public SaleActiveStatus GetSaleActiveStatus(int id)
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetSaleActiveStatus(id);
            return results;
        }

        public Sale GetSaleByUnitId(int id)
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetSaleByUnitId(id);
            return results;
        }

        public List<SaleType> GetSaleTypes()
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetSaleTypes();
            return results;
        }

        public List<SaleDepositProof> GetDepositTypes()
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetDepositTypes();
            return results;
        }

        public List<Bank> GetAllBanks()
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetAllBanks();
            return results;
        }

        public List<MOStatus> GetAllMOStatus()
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetAllMOStatus();
            return results;
        }
        
        public List<OriginatorTr> GetOriginatorBySalesId(int id)
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetOriginatorBySalesId(id);
            return results;
        }
        public OriginatorTr GetOriginatorById(int id)
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetOriginatorById(id);
            return results;
        }

        public Bank GetBankById(int id)
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetBankById(id);
            return results;
        }

        public MOStatus GetMOStatusById (int id)
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetMOStatusById(id);
            return results;
        }

        public List<SalesReportViewModel> GetSalesReport()
        {
            _salesRepo = new SalesRepository(_dbContext);
            var results = _salesRepo.GetSalesReport();
            return results;

        }

         public void SaveUpdateReservation(Sale reservation)
         {
            _salesRepo = new SalesRepository(_dbContext);
            _salesRepo.Update(reservation);
        }

         public void AddSale(Sale newSale)
         {
             _salesRepo = new SalesRepository(_dbContext);
             _salesRepo.Add(newSale);
         }

         public void UpdateSale(Sale sale)
         {
             _salesRepo = new SalesRepository(_dbContext);
             _salesRepo.Update(sale);
         }

         public Individual SavePerson(Individual person)
        {
            _personRepo = new IndividualRepository(_dbContext);
            _personRepo.Add(person);

            return person;
        }

         public Purchaser SavePurchaser(Purchaser purchaser)
         {
             _purchaserRepo = new PurchaserRepository(_dbContext);
             _purchaserRepo.Add(purchaser);

             return purchaser;
         }

         public Purchaser UpdatePurchaser(Purchaser purchaser)
         {
             _purchaserRepo = new PurchaserRepository(_dbContext);
             _purchaserRepo.Update(purchaser);

             return purchaser;
         }

         public Purchaser GetPurchaserById(int id)
         {
             _purchaserRepo = new PurchaserRepository(_dbContext);
             var results = _purchaserRepo.GetPurchaserById(id);
             return results;
         }

         public List<EntityType> GetPurchaserEntityTypes()
         {
            _purchaserRepo = new PurchaserRepository(_dbContext);
            var results = _purchaserRepo.GetPurchaserEntityTypes();
            return results;
         }

        public PreferedContactMethod GetPreferedContactMethodById(int id)
        {
            _personRepo = new IndividualRepository(_dbContext);
            var results =_personRepo.GetPreferedContactMethodById(id);
            return results;
        }

        public List<PreferedContactMethod> GetAllPreferedContactMethods()
        {
            _personRepo = new IndividualRepository(_dbContext);
            var results = _personRepo.GetAllPreferedContactMethods();
            return results;
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

        public void SaveOrginator(OriginatorTr originatorTr)
        {
            _orginatorRepo = new OrginatorRepository(_dbContext);
            _orginatorRepo.Add(originatorTr);
        }
        public void UpdateOrginator(OriginatorTr originatorTr)
        {
            _orginatorRepo = new OrginatorRepository(_dbContext);
            _orginatorRepo.Update(originatorTr);
        }


    }
}
