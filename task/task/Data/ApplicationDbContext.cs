using Microsoft.EntityFrameworkCore;
using task.Models;
namespace task.Data

{
    namespace Task.Infrastructure.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Product> Products { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Product>()
                    .HasIndex(p => new { p.ManufactureEmail, p.ProduceDate })
                    .IsUnique();

                base.OnModelCreating(modelBuilder);
            }
        }
    }
}
