using FinTransact.TransactionAPI.Dtos.Transaction;
using System.Transactions;

namespace FinTransact.TransactionAPI.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IReadOnlyList<ReturnTransactionDto>> GetTransactionListWithAssociteData();
        Task<ReturnTransactionDto> GetTransactionByIdWithAssociateData(int id);
    }
}
