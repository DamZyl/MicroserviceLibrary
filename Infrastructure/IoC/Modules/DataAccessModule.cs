using System;
using Autofac;
using MicroserviceLibrary.Application.Configurations.Data;
using MicroserviceLibrary.Application.Configurations.Options;
using MicroserviceLibrary.Infrastructure.Databases;
using MicroserviceLibrary.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MicroserviceLibrary.Infrastructure.IoC.Modules
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        private readonly string _assembly;

        public DataAccessModule(IConfiguration configuration, string assembly)
        {
            _configuration = configuration;
            _assembly = assembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var dbConfig = _configuration.GetSection(Consts.DbConfigurationSection).Get<SqlOption>();
            
            builder.Register(p => dbConfig).SingleInstance();
            
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", dbConfig.ConnectionString)
                .InstancePerLifetimeScope();


            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<AbstractApplicationDbContext>();
                    dbContextOptionsBuilder.UseSqlServer(dbConfig.ConnectionString, options => 
                        options.MigrationsAssembly(_assembly));

                    return Activator.CreateInstance<AbstractApplicationDbContext>();
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}