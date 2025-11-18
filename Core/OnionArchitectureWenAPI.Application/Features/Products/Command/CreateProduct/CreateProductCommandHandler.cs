using MediatR;
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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product, CreateProductCommandRequest>(request);
            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            var result =  await _unitOfWork.SaveChangesAsync();
            if(result > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new () { ProductId = product.Id, CategoryId = categoryId });
                }
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
