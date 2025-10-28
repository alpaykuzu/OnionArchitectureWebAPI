using MediatR;
using OnionArchitectureWebAPI.Application.Interfaces.UnitofWorks;
using OnionArchitectureWebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitofWork _unitofWork;

        public GetAllProductsQueryHandler(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitofWork.GetReadRepository<Product>().GetAllAsync();
            List<GetAllProductsQueryResponse> response = products.Select(p => new GetAllProductsQueryResponse
            {
                Title = p.Title,
                Description = p.Description,
                Discount = p.Discount,
                Price = p.Price - (p.Price * p.Discount / 100),
            }).ToList();
            return response;
        }
    }
}
