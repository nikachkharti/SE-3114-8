using MiniBank.Models;
using MiniBank.Service.Implementations;
using MiniBank.Service.Interfaces;

namespace MiniBank.UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IDbService _dbService = new DbService();

            await AllCustomers(_dbService);

            //Customer newCustomer = new();
            //newCustomer.Name = "ბექა ათაბაკი";
            //newCustomer.PhoneNumber = "558997744";
            //newCustomer.IdentityNumber = "01025896324";
            //newCustomer.CustomerType = CustomerType.Phyisical;
            //newCustomer.Email = "Beka@gmail.com";

            //await AddNewCustomer(_dbService, newCustomer);
        }

        private static async Task AddNewCustomer(IDbService dbService, Customer newCustomer)
        {
            await dbService.AddNewCustomer(newCustomer);
        }


        private static async Task AllCustomers(IDbService _dbService)
        {
            var allCustomers = await _dbService.GetCustomers();
            DisplayCustomers(allCustomers);
        }

        private static void DisplayCustomers(List<Models.Customer> allCustomers)
        {
            foreach (var customer in allCustomers)
            {
                Console.WriteLine($"{customer.Name}---{customer.Email}");
            }
        }
    }
}
