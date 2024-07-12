namespace FinTransact.TransactionAPI.Entities
{
    public class BankAccount : BaseEntity
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }
    }
}
