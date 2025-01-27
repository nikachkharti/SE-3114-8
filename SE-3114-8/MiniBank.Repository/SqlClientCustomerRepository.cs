using MiniBank.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using MiniBank.Repository.Interfaces;

namespace MiniBank.Repository
{
    public class SqlClientCustomerRepository
    {
        private const string _connectionString = "Server=DESKTOP-SCSHELD\\SQLEXPRESS;Database=MiniBankSE31148;Trusted_Connection=true;TrustServerCertificate=true";
        private readonly IRepository<Customer> _repository;

        public SqlClientCustomerRepository()
        {
            _repository = new Repositroy<Customer>(_connectionString);
        }


        public async Task<List<Customer>> GetCustomers()
        {
            string commandText = "spGetAllCustomers";
            var result = await _repository.GetAll(commandText, null, CommandType.StoredProcedure);

            return result.ToList();
        }



        public async Task<Customer> GetCustomer(int id)
        {
            string commandText = "spGetSingleCustomer";
            Customer result = new();

            using (SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("customerId", id);

                    await connection.OpenAsync();

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        result.Id = reader.GetInt32(0);
                        result.Name = reader.GetString(1);
                        result.IdentityNumber = reader.GetString(2);
                        result.PhoneNumber = reader.GetString(3);
                        result.Email = reader.GetString(4);
                        result.Type = Enum.Parse<CustomerType>(reader.GetByte(5).ToString());
                    }
                }
            }

            return result;
        }
        public async Task Create(Customer customer)
        {
            string commandText = "spCreateCustomer";

            using (SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();

                    command.Parameters.AddWithValue("name", customer.Name);
                    command.Parameters.AddWithValue("identityNumber", customer.IdentityNumber);
                    command.Parameters.AddWithValue("phoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("email", customer.Email);
                    command.Parameters.AddWithValue("customerType", customer.Type);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Update(Customer customer)
        {
            string commandText = "spUpdateCustomer";

            using (SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();

                    command.Parameters.AddWithValue("customerId", customer.Id);
                    command.Parameters.AddWithValue("name", customer.Name);
                    command.Parameters.AddWithValue("identityNumber", customer.IdentityNumber);
                    command.Parameters.AddWithValue("phoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("email", customer.Email);
                    command.Parameters.AddWithValue("customerType", customer.Type);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Delete(int id)
        {
            string commandText = "spDeleteCustomer";

            using (SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();

                    command.Parameters.AddWithValue("customerId", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
