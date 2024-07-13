using System.ComponentModel.DataAnnotations;

namespace FinTransact.TransactionAPI.Dtos.BankAccount
{
    public class AddBankAccountDto
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Account Number must be between 5 and 20 characters.")]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Account Holder Name must be between 2 and 50 characters.")]
        public string AccountHolderName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Balance must be a positive value.")]
        public decimal Balance { get; set; }

 
    }
}
