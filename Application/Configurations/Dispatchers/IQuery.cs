using MediatR;

namespace MicroserviceLibrary.Application.Configurations.Dispatchers
{
    public interface IQuery<out TResult> : IRequest<TResult> { }
}