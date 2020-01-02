using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfServiceTestEuqip
{
    [ServiceContract]
    public interface IServiceEuqip
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "api/getEquip/{id}", ResponseFormat = WebMessageFormat.Json)]
        EquipView GetEquip(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "api/getEquipAll", ResponseFormat = WebMessageFormat.Json)]
        List<EquipView> GetAllEquip();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "api/createEquip", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool CreateEq(Equipment equipment);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "api/updateEq", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateEq(Equipment equipment);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "api/removeEq", ResponseFormat = WebMessageFormat.Json)]
        bool RemoveEq(Equipment equipment);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "api/getEquip/?departament={dept}", ResponseFormat = WebMessageFormat.Json)]
        List<EquipView> GetEquipsByDept(string dept);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "api/getDeparts", ResponseFormat = WebMessageFormat.Json)]
        List<Depart> GetDeparts();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "api/getDeparts/{id}", ResponseFormat = WebMessageFormat.Json)]
        Depart GetDepart(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "api/createDept", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool CreateDept(Depart depart);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "api/updateDept", RequestFormat=WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateDept(Depart depart);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "api/removeDept", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool RemoveDept(Depart depart);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "api/getManufs", ResponseFormat = WebMessageFormat.Json)]
        List<Manufact> GetManufacts();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "api/getManuf/{id}", ResponseFormat = WebMessageFormat.Json)]
        Manufact GetManufact(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "api/createManuf", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool CreateManuf(Manufact manufact);


        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "api/updateManuf", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateManuf(Manufact manufact);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "api/removeManuf", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool RemoveManuf(Manufact manufact);
    }
}
