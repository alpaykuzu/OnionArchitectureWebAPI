using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnionArchitectureWebAPI.Application.Bases;
using OnionArchitectureWebAPI.Application.Features.Auth.Exceptions;
using OnionArchitectureWebAPI.Application.Features.Auth.Rules;
using OnionArchitectureWebAPI.Application.Interfaces.AutoMapper;
using OnionArchitectureWebAPI.Application.Interfaces.UnitofWorks;
using OnionArchitectureWebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;


        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitofWork unitofWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitofWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new UserCannotCreate();
            else {                 
                if (!await roleManager.RoleExistsAsync("User"))
                {
                    Role role = new Role()
                    {
                        Id = Guid.NewGuid(),
                        Name = "User",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    };
                    await roleManager.CreateAsync(role);
                }
                await userManager.AddToRoleAsync(user, "User");
            }
            return Unit.Value;
        }
    }
}
