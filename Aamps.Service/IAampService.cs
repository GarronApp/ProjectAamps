using Aamps.Domain.Models;
using Aamps.Domain.Queries.Developments;
using Aamps.Domain.Queries.Reports.Bonds;
using Aamps.Domain.Queries.Reports.Sales;
using Aamps.Domain.Queries.Units;
using Aamps.Domain.ValueObjects;
using Aamps.Domain.ViewModels.Development;
using Aamps.Domain.ViewModels.Reports.Sales;
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
        List<Unit> GetUnitsByDevelopment(int id);

        [OperationContract]
        List<Unit> GetAllUnAvailableUnits(int id);

        [OperationContract]
        List<Unit> GetDevelopmentUnits(SelectRelevantUnitsQuery query);

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
        List<SalesReportQuery> GetSalesReport(int id);

        [OperationContract]
        List<BondsReportQuery> GetBondsReport(int id);

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
        List<AgentDevelopmentViewModel> GetDevelopmentsByAgent(SelectRelevantDevelopmentQuery query);

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
         Individual SaveIndividual(Individual person);
         [OperationContract]
         Individual UpdateIndividual(Individual person);
         [OperationContract]
         List<PreferedContactMethod> GetAllPreferedContactMethods();
         [OperationContract]
         PreferedContactMethod GetPreferedContactMethodById(int id);
         [OperationContract]
         Individual GetIndividualById(int id);
         [OperationContract]
         [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
         List<Individual> ValidateIndividual(string lastname, string cellphone, string email);
         

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


        [OperationContract]
        UserRight GetUserPermissions(int user);

        //Enums

        [OperationContract]
        int GetUnitStatusTypes(GetUnitStatusType type);

        [OperationContract]
        int GetSaleActiveStatusTypes(GetSaleActiveStatusType type);

        [OperationContract]
        int GetSaleStatusTypes(GetSaleStatusType type);

        
    }
}
