using System.ServiceModel;

namespace SampleSoap.Models
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        string Ping(string s);

        [OperationContract]
        ComplexModelResponse PingComplexModel(ComplexModelInput inputModel);

        [OperationContract]
        int[] IntArray();

        [OperationContract]
        ComplexReturnModel[] ComplexReturnModel();

        [OperationContract]
        void VoidMethod(out string s);

        [OperationContract]
        Task<int> AsyncMethod();

        [OperationContract]
        int? NullableMethod(bool? arg);

        [OperationContract]
        void XmlMethod(System.Xml.Linq.XElement xml);

        [OperationContract]
        List<Customer> GetCustomers();

        [OperationContract]
        Customer? GetCustomer(int id);

        [OperationContract]
        Customer CreateCustomer(Customer customer);

        [OperationContract]
        void UpdateCustomer(int id, Customer customer);

        [OperationContract]
        void DeleteCustomer(int id);
    }
}