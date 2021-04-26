using System;

namespace MicroserviceLibrary.Domain.SharedKernels
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}