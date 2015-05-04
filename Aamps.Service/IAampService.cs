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



        //Sales Service

        [OperationContract]
        List<Sale> GetAllSales();

        [OperationContract]
        Sale GetSaleById(int id);

        [OperationContract]
        Sale GetSaleByUnitId(int id);

        [OperationContract]
        void SaveUpdateReservation(Sale sale);

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
        void SavePerson(Individual person);

        //User
        [OperationContract]
        UserList GetUser(int identity);

        [OperationContract]
        UserList GetCurrentUser(string username);

        
    }
}
