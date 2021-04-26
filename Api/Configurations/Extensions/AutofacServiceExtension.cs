using Autofac;
using Autofac.Extensions.DependencyInjection;
using MicroserviceLibrary.Infrastructure.IoC.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceLibrary.Api.Configurations.Extensions
{
    public static class AutofacServiceExtension
    {
        public static IContainer CreateContainer(IServiceCollection services, IConfiguration configuration, 
            string migrationAssembly, string applicationAssembly)
        {
            var builder = new ContainerBuilder();
            
            builder.Populate(services);
            builder.RegisterModule(new InfrastructureModule(configuration, migrationAssembly, applicationAssembly));
            
            return builder.Build();
        }
    }
}