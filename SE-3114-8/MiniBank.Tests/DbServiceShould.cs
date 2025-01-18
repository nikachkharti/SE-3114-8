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
    }
}
