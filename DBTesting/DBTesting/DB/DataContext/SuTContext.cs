using DBTesting.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DBTesting.DB.DataContext
{
    public class SuTContext : DbContext
    {
        public SuTContext(DbContextOptions<SuTContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>();
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
