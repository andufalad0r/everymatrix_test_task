using EveryMatrixApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EveryMatrixApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>();
        }
    }
}
