using FinTransact.AuthAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FinTransact.AuthAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
