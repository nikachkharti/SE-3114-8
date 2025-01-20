using MiniBank.Models;

namespace MiniBank.Service.Interfaces
{
    public interface IDbService
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int customerId);
        Task AddNewCustomer(Customer model);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(Customer model);
    }
}
