using MediatR;
using Microsoft.AspNetCore.Http;
using OnionArchitectureWebAPI.Application.Bases;
using OnionArchitectureWebAPI.Application.Features.Products.Rules;
using OnionArchitectureWebAPI.Application.Interfaces.AutoMapper;
using OnionArchitectureWebAPI.Application.Interfaces.UnitofWorks;
using OnionArchitectureWebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly ProductRules _productRules;

        public CreateProductCommandHandler(ProductRules productRules, IMapper mapper, IUnitofWork unitofWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitofWork, httpContextAccessor) 
        {
            _productRules = productRules;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var existingProducts = await unitOfWork.GetReadRepository<Product>()
                .GetAllAsync();
            await _productRules.ProductTitleMustNotBeSame(request.Title, existingProducts.Select(p => p.Title).ToList()); 

            var product = mapper.Map<Product>(request);
            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            var result =  await unitOfWork.SaveChangesAsync();
            if(result > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new () { ProductId = product.Id, CategoryId = categoryId });
                }
                await unitOfWork.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
