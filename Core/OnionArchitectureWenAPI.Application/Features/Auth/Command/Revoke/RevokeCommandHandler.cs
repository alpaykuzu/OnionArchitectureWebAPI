using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnionArchitectureWebAPI.Application.Bases;
using OnionArchitectureWebAPI.Application.Features.Auth.Rules;
using OnionArchitectureWebAPI.Application.Interfaces.AutoMapper;
using OnionArchitectureWebAPI.Application.Interfaces.UnitofWorks;
using OnionArchitectureWebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;

        public RevokeCommandHandler(UserManager<User> userManager, AuthRules authRules, IMapper mapper, IUnitofWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByIdAsync(userId);
            await authRules.UserShouldExistWhenRequested(user);

            user.RefreshToken = null;
            user.RefreshTokenExpireTime = null;
            await userManager.UpdateAsync(user);
            return Unit.Value;
        }
    }
}
