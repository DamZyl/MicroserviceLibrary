using MediatR;

namespace MicroserviceLibrary.Application.Configurations.Dispatchers
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult> { }
}