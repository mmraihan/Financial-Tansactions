namespace FinTransact.TransactionAPI.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string AccountType { get; set; }
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
