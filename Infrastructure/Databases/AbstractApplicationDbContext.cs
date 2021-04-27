using System.Reflection;
using MicroserviceLibrary.Application.Configurations.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MicroserviceLibrary.Infrastructure.Databases
{
    public abstract class AbstractApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbContext Instance => this;

        private readonly IOptions<SqlOption> _sqlOption;
        private readonly string _migrationAssembly;

        protected AbstractApplicationDbContext(IOptions<SqlOption> sqlOption, string migrationAssembly)
        {
            _sqlOption = sqlOption;
            _migrationAssembly = migrationAssembly;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(_sqlOption.Value.ConnectionString, 
                options => options.MigrationsAssembly(_migrationAssembly));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}