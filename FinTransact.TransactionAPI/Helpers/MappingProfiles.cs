using AutoMapper;
using FinTransact.TransactionAPI.Dtos.BankAccount;
using FinTransact.TransactionAPI.Dtos.Transaction;
using FinTransact.TransactionAPI.Entities;

namespace FinTransact.TransactionAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region BankAccount

            CreateMap<BankAccount, ReturnBankAccountDto>();
            CreateMap<AddBankAccountDto, BankAccount>();
            CreateMap<UpdateBankAccountDto, BankAccount>();

            #endregion


            #region Transaction

            CreateMap<Transaction, ReturnTransactionDto>();
            CreateMap<AddTransactionDto, Transaction>();
            CreateMap<UpdateTransactionDto, Transaction>();

            #endregion

        }
    }
}
