using GenericRepositoryPattern.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPattern.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here if needed
        }
    }

}
