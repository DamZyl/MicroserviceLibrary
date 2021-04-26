using System;
using System.Collections.Generic;
using MicroserviceLibrary.Application.Dto;

namespace MicroserviceLibrary.Application.Auths
{
    public interface IJwtHandler
    {
        string CreateToken(Guid userId, string fullName, List<AuthDto> auths);
    }
}