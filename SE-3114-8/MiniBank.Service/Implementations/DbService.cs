using Microsoft.Data.SqlClient;
using MiniBank.Models;
using MiniBank.Service.Interfaces;

namespace MiniBank.Service.Implementations
{
    public class DbService : IDbService
    {
        public async Task<List<Customer>> GetCustomers()
        {
            const string connectionString = "Server=DESKTOP-SCSHELD\\SQLEXPRESS;Database=MiniBankSE31148;Trusted_Connection=True;TrustServerCertificate=True";
            List<Customer> customers = new();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT*FROM Customers";

                using (var command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        customers.Add(new Customer()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            IdentityNumber = reader.GetString(2),
                            PhoneNumber = reader.GetString(3),
                            Email = reader.GetString(4),
                            CustomerType = Enum.Parse<CustomerType>(reader.GetInt32(5).ToString())
                        });
                    }

                }
            }

            return customers;
        }

    }
}
