using MiniBank.Models;
using MiniBank.Service.Implementations;
using MiniBank.Service.Interfaces;

namespace MiniBank.Tests
{
    public class DbServiceShould
    {
        private readonly IDbService _dbService;
        public DbServiceShould()
        {
            _dbService = new DbService();
        }


        [Fact]
        public async Task Get_All_Customers()
        {
            var result = await _dbService.GetCustomers();
        }

        [Fact]
        public async Task Add_Customer()
        {
            var newCustomer = new Customer();
            newCustomer.Name = "ბექა ათაბაკი";
            newCustomer.PhoneNumber = "558997744";
            newCustomer.IdentityNumber = "01025896324";
            newCustomer.CustomerType = CustomerType.Phyisical;
            newCustomer.Email = "Beka@gmail.com";

            await _dbService.AddNewCustomer(newCustomer);
        }


        [Fact]
        public async Task Delete_Customer()
        {
            await _dbService.DeleteCustomer(1);
        }


        [Fact]
        public async Task Update_Customer()
        {
            var newCustomer = new Customer();
            newCustomer.Id = 12;
            newCustomer.Name = "საბა ათაბაკი";
            newCustomer.PhoneNumber = "558997744";
            newCustomer.IdentityNumber = "01025896324";
            newCustomer.CustomerType = CustomerType.Phyisical;
            newCustomer.Email = "Saba@gmail.com";

            await _dbService.UpdateCustomer(newCustomer);
        }
    }
}
