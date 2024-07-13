using FinTransact.TransactionAPI.Dtos.BankAccount;

namespace FinTransact.TransactionAPI.Dtos.Transaction
{
    public class ReturnTransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string AccountType { get; set; }
        public int BankAccountId { get; set; }
        public ReturnBankAccountDto BankAccount{ get; set; }

    }
}
