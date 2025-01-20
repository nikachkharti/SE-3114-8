namespace MiniBank.Models
{
    public class Account
    {
        /// <summary>
        /// Id PK IDENTITY
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 22 ნიშნა
        /// </summary>
        public string Iban { get; set; }

        /// <summary>
        /// 3 ნიშნა
        /// </summary>
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }

        /// <summary>
        /// დანიშნულება
        /// </summary>
        public string Name { get; set; }
    }
}
