using MicroserviceLibrary.Application.Configurations.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MicroserviceLibrary.Infrastructure.Databases
{
    public abstract class AbstractApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbContext Instance => this;

        private readonly IOptions<SqlOption> _sqlOption;

        protected AbstractApplicationDbContext(IOptions<SqlOption> sqlOption)
        {
            _sqlOption = sqlOption;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(_sqlOption.Value.ConnectionString);
        }
    }
}