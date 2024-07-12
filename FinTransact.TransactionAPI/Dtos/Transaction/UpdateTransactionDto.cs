namespace FinTransact.TransactionAPI.Dtos.Transaction
{
    public class UpdateTransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string AccountType { get; set; }
        public int BankAccountId { get; set; }
    }
}
