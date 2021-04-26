using System;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceLibrary.Infrastructure.Databases
{
    public interface IApplicationDbContext : IDisposable
    {
        DbContext Instance { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}