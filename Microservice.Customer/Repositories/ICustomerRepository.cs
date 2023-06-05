using Microservice.Customer.Models;

namespace Microservices.Customer.Repositories
{
    public interface ICustomerRepository
    {
        void AddCustomer(CustomerModel customer);
        void DeleteCustomer(int id);
        IEnumerable<CustomerModel> GetAllCustomers();
        CustomerModel? GetCustomerById(int id);
        void UpdateCustomer(CustomerModel customer);
    }
}