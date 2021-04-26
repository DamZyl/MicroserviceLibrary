using MicroserviceLibrary.Domain.SharedKernels;

namespace MicroserviceLibrary.Application.Rules
{
    public class SplitPasswordToPartLengthRule : IBusinessRule
    {
        private readonly string[] _parts;

        public SplitPasswordToPartLengthRule(string[] parts)
        {
            _parts = parts;
        }

        public bool IsBroken() => _parts.Length != 3;

        public string Message => "Invalid credentials.";
    }
}