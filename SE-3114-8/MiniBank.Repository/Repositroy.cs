using Microsoft.Data.SqlClient;
using MiniBank.Repository.Interfaces;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;

namespace MiniBank.Repository
{
    public class Repositroy<T> : IRepository<T> where T : class, new()
    {
        private readonly string _connectionString;
        public Repositroy(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<int> Execute(string query, object parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get(string query, Dictionary<string, object> parameters, CommandType commandType = CommandType.Text)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text)
        {
            var results = new List<T>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = commandType;

                    // Add parameters if provided
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            T result = new T();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                object columnValue = reader.GetValue(i);

                                // Get the property with the same name as the column name
                                PropertyInfo prop = typeof(T).GetProperty(columnName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

                                if (prop != null && columnValue != DBNull.Value)
                                {
                                    prop.SetValue(result, Convert.ChangeType(columnValue, prop.PropertyType));
                                }
                            }
                            results.Add(result);
                        }
                    }
                }
            }
            return results;
        }

    }
}
