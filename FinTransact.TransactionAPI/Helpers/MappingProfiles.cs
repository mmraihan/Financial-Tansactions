using AutoMapper;
using FinTransact.TransactionAPI.Dtos.BankAccount;
using FinTransact.TransactionAPI.Entities;

namespace FinTransact.TransactionAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BankAccount, ReturnBankAccountDto>();
            CreateMap<AddBankAccountDto, BankAccount>();
            CreateMap<UpdateBankAccountDto, BankAccount>();
        }
    }
}
