using FinTransact.TransactionAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinTransact.TransactionAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
