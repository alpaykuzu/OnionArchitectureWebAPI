using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitectureWebAPI.Application.Features.Brands.Command.CreateBrand;
using OnionArchitectureWebAPI.Application.Features.Brands.Queries.GetAllBrands;
using OnionArchitectureWebAPI.Application.Features.Products.Queries.GetAllProducts;

namespace OnionArchitectureWebApi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            return Ok(await _mediator.Send(new GetAllBrandsQueryRequest()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
