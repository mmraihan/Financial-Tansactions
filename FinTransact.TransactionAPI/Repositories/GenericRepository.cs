using FinTransact.TransactionAPI.Data;
using FinTransact.TransactionAPI.Entities;
using FinTransact.TransactionAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinTransact.TransactionAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            return await SaveChangesAsync();
        }

        #region Private Method

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        #endregion



    }
}
