using System.Data;

namespace MiniBank.Repository.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<IEnumerable<T>> GetAll(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text);
        Task<T> Get(string query, Dictionary<string, object> parameters, CommandType commandType = CommandType.Text);
        Task<int> Execute(string query, object parameters);
    }
}
