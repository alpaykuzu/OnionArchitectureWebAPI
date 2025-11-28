using OnionArchitectureWebAPI.Application.Bases;
using OnionArchitectureWebAPI.Application.Features.Auth.Exceptions;
using OnionArchitectureWebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if(user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
        public Task EmailOrPasswordShouldNotBeWrong(User? user, bool checkPassword)
        {
            if (!checkPassword || user is null) throw new EmailOrPasswordWrongException();
            return Task.CompletedTask;
        }
        public Task RefreshTokenShouldNotBeExpired(DateTime? expireDate)
        {
            if (expireDate < DateTime.Now.ToLocalTime() || expireDate is null) throw new RefreshTokenExpiredException();
            return Task.CompletedTask;
        }
        public Task UserShouldExistWhenRequested(User? user)
        {
            if (user is null) throw new UserNotFoundException();
            return Task.CompletedTask;
        }
    }
}
