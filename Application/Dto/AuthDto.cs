using System;

namespace MicroserviceLibrary.Application.Dto
{
    public class AuthDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string AuthName { get; set; }
    }
}