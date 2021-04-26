using Autofac;
using Microsoft.Extensions.Configuration;

namespace MicroserviceLibrary.Infrastructure.IoC.Modules
{
    public class InfrastructureModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        private readonly string _migrationAssembly;
        private readonly string _applicationAssembly;

        public InfrastructureModule(IConfiguration configuration, string migrationAssembly, string applicationAssembly)
        {
            _configuration = configuration;
            _migrationAssembly = migrationAssembly;
            _applicationAssembly = applicationAssembly;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AuthModule());
            builder.RegisterModule(new DataAccessModule(_configuration, _migrationAssembly));
            builder.RegisterModule(new MediatrModule(_applicationAssembly));
            builder.RegisterModule(new RepositoryModule());
        }
    }
}