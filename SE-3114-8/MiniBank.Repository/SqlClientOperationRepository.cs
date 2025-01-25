using MiniBank.Models;

namespace MiniBank.Repository
{
    public class SqlClientOperationRepository
    {
        private const string _connectionString = "Server=DESKTOP-SCSHELD\\SQLEXPRESS;Database=MiniBankSE31148;Trusted_Connection=true;TrustServerCertificate=true";
        SqlClientAccountRepository _sqlClietnAccountRepository = new();


        public async Task Withdraw(int accountId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(int accountId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public async Task Transfer(int sourceAccountId, int destinationAccountId, decimal amount)
        {
            throw new NotImplementedException();
        }


        //ახალი ჩანაწერი Operation ცხრილში.
        public async Task Create(Operation operation)
        {
            throw new NotImplementedException();
        }
    }
}
