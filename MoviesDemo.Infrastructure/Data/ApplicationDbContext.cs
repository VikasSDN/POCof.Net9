using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MoviesDemo.Core.Entities;

namespace MoviesDemo.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<MoviesEntity> Movies { get; set; }

        public DbContextOptionsBuilder DbContextOptionsBuilder => new DbContextOptionsBuilder(options);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
