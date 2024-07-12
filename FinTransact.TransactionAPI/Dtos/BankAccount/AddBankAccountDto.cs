namespace FinTransact.TransactionAPI.Dtos.BankAccount
{
    public class AddBankAccountDto
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
