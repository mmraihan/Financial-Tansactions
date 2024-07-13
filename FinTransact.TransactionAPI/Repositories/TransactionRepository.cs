using AutoMapper;
using FinTransact.TransactionAPI.Data;
using FinTransact.TransactionAPI.Dtos.Transaction;
using FinTransact.TransactionAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinTransact.TransactionAPI.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TransactionRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnTransactionDto> GetTransactionByIdWithAssociateData(int id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.BankAccount)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transaction == null)
            {
                return null;
            }

            return _mapper.Map<ReturnTransactionDto>(transaction);
        }

        public async Task<IReadOnlyList<ReturnTransactionDto>> GetTransactionListWithAssociteData()
        {
            var transactions = await _context.Transactions
                .Include(t => t.BankAccount)
                .ToListAsync();

            return _mapper.Map<IReadOnlyList<ReturnTransactionDto>>(transactions);
        }

     
    }
}
