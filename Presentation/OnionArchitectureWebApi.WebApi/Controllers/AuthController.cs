using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitectureWebAPI.Application.Features.Auth.Command.Login;
using OnionArchitectureWebAPI.Application.Features.Auth.Command.RefreshToken;
using OnionArchitectureWebAPI.Application.Features.Auth.Command.Register;
using OnionArchitectureWebAPI.Application.Features.Auth.Command.Revoke;
using OnionArchitectureWebAPI.Application.Features.Auth.Command.RevokeAll;

namespace OnionArchitectureWebApi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterCommandRequest request)
        {
            return Ok(await mediator.Send(request));
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequest request)
        {
            return Ok(await mediator.Send(request));
        }
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommandRequest request)
        {
            return Ok(await mediator.Send(request));
        }
        [HttpPost]
        public async Task<IActionResult> Revoke()
        {
            return Ok(await mediator.Send(new RevokeCommandRequest()));
        }
        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            return Ok(await mediator.Send(new RevokeAllCommandRequest()));
        }
    }
}
