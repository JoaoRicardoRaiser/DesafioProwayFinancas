using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DesafioProwayFinancas.Database
{
    public class DesafioProwayFinancasDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DbInfoProvider.GetPostgresConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
