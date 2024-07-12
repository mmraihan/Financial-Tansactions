namespace FinTransact.TransactionAPI.Dtos.BankAccount
{
    public class UpdateBankAccountDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }
    }
}
