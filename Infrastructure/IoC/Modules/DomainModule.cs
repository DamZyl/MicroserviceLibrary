using System.Reflection;
using Autofac;
using MicroserviceLibrary.Domain.SharedKernels;

namespace MicroserviceLibrary.Infrastructure.IoC.Modules
{
    public class DomainModule : Autofac.Module
    {
        private readonly string _assembly;

        public DomainModule(string assembly)
        {
            _assembly = assembly;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.LoadFrom(_assembly);

            builder.RegisterAssemblyTypes(assembly)
                .AssignableTo<IDomainService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}