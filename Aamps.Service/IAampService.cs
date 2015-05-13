using Aamps.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Service
{
    [ServiceContract]
    public interface IAampService
    {
        //Unit Service

        [OperationContract]
        //[WebInvoke(UriTemplate = "/Units", BodyStyle = WebMessageBodyStyle.Bare, Method = "GET")]
        List<Unit> GetAllUnits();

        [OperationContract]
        //[WebInvoke(UriTemplate = "/Units?id={id}", BodyStyle = WebMessageBodyStyle.Bare, Method = "GET")]
        Unit GetUnitById(int id);

        [OperationContract]
        List<Unit> GetAllAvailableUnits(int id);

        [OperationContract]
        List<Unit> GetAllUnAvailableUnits(int id);

        [OperationContract]
        Unit GetUnitByUnitBlock(string block);

        [OperationContract]
        Unit GetUnitByAddedUser(int user);

        [OperationContract]
        Unit GetUnitByAgentId(int agent);

        [OperationContract]
        List<Unit> GetUnitByDevelopmentId(int id);

        [OperationContract]
        void UpdateUnit(Unit unit);

        //Orginator Service
        [OperationContract]
        void UpdateOrginator(OriginatorTr originatorTr);
        [OperationContract]
        void SaveOrginator(OriginatorTr originatorTr);

        //Sales Service

        [OperationContract]
        List<Sale> GetAllSales();

        [OperationContract]
        Sale GetSaleById(int id);

        [OperationContract]
        SaleActiveStatus GetSaleActiveStatus(int id);

        [OperationContract]
        List<SaleType> GetSaleTypes();

        [OperationContract]
        List<SaleDepositProof> GetDepositTypes();

        [OperationContract]
        Bank GetBankById(int id);

        [OperationContract]
        List<Bank> GetAllBanks();

        [OperationContract]
        MOStatus GetMOStatusById(int id);

        [OperationContract]
        List<MOStatus> GetAllMOStatus();

        [OperationContract]
        List<OriginatorTr> GetOriginatorBySalesId(int id);

        [OperationContract]
        OriginatorTr GetOriginatorById(int id);

        [OperationContract]
        Sale GetSaleByUnitId(int id);

        [OperationContract]
        void SaveUpdateReservation(Sale sale);

        [OperationContract]
        void AddSale(Sale sale);

        [OperationContract]
        void UpdateSale(Sale sale);

        //Development Service

        [OperationContract]
        List<Development> GetAllDevelopments();

        [OperationContract]
        Development GetDevelopmentById(int id);

        [OperationContract]
        Estate GetEstateByDevelopment(int id);

        [OperationContract]
        UnitStatus GetUnitStatusById(int id);
        [OperationContract]
        List<Company> GetCompanies();
        [OperationContract]
        Company GetCompanyByUserGroupId(int id);

        //Individual
         [OperationContract]
         Individual SavePerson(Individual person);
         [OperationContract]
         List<PreferedContactMethod> GetAllPreferedContactMethods();
         [OperationContract]
         PreferedContactMethod GetPreferedContactMethodById(int id);

        //Purchaser
         [OperationContract]
         Purchaser SavePurchaser(Purchaser purchaser);
         [OperationContract]
         Purchaser UpdatePurchaser(Purchaser purchaser);
         [OperationContract]
         Purchaser GetPurchaserById(int id);
         [OperationContract]
         List<EntityType> GetPurchaserEntityTypes();

        //User
        [OperationContract]
        UserList GetUser(int identity);

        [OperationContract]
        UserList GetCurrentUser(string username);

        
    }
}
