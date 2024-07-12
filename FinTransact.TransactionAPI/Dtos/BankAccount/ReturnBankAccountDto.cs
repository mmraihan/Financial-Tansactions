namespace FinTransact.TransactionAPI.Dtos.BankAccount
{
    public class ReturnBankAccountDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }
    }
}
