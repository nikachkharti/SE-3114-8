using MiniBank.Models;

namespace MiniBank.Service.Interfaces
{
    public interface IDbService
    {
        Task<List<Customer>> GetCustomers();
    }
}
