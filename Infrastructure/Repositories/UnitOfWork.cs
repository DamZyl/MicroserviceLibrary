using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MicroserviceLibrary.Domain.Repositories;
using MicroserviceLibrary.Domain.SharedKernels;
using MicroserviceLibrary.Infrastructure.Databases;

namespace MicroserviceLibrary.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        
        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class, IAggregateRoot
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            IGenericRepository<TEntity> repository = new GenericRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _context.Instance.SaveChangesAsync(cancellationToken);
        }

        public void Rollback()
        {
            _context.Instance.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}