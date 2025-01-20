﻿using Microsoft.Data.SqlClient;
using MiniBank.Models;
using MiniBank.Service.Interfaces;
using System.Data;

namespace MiniBank.Service.Implementations
{
    public class DbService : IDbService
    {
        private const string _connectionString = "Server=DESKTOP-SCSHELD\\SQLEXPRESS;Database=MiniBankSE31148;Trusted_Connection=True;TrustServerCertificate=True";

        public async Task AddNewCustomer(Customer model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "spCreateCustomer";

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("name", model.Name);
                    command.Parameters.AddWithValue("identityNumber", model.IdentityNumber);
                    command.Parameters.AddWithValue("phoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("email", model.Email);
                    command.Parameters.AddWithValue("customerType", model.CustomerType);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteCustomer(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "spDeleteCustomer";

                using (SqlCommand command = new(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("customerId", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public Task<Customer> GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = new();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "spGetAllCustomers";

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

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

        public async Task UpdateCustomer(Customer model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "spUpdateCustomer";

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("customerId", model.Id);
                    command.Parameters.AddWithValue("name", model.Name);
                    command.Parameters.AddWithValue("identityNumber", model.IdentityNumber);
                    command.Parameters.AddWithValue("phoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("email", model.Email);
                    command.Parameters.AddWithValue("customerType", model.CustomerType);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
