namespace MicroserviceLibrary.Domain.SharedKernels
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}