using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitectureWebAPI.Application.Features.Brands.Command.CreateBrand;
using OnionArchitectureWebAPI.Application.Features.Products.Command.CreateProduct;
using OnionArchitectureWebAPI.Application.Features.Products.Command.DeleteProduct;
using OnionArchitectureWebAPI.Application.Features.Products.Command.UpdateProduct;
using OnionArchitectureWebAPI.Application.Features.Products.Queries.GetAllProducts;

namespace OnionArchitectureWebApi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _mediator.Send(new GetAllProductsQueryRequest()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
