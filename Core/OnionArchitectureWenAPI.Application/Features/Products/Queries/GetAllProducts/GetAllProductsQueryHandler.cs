using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionArchitectureWebAPI.Application.DTOs;
using OnionArchitectureWebAPI.Application.Interfaces.AutoMapper;
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
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitofWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));

            mapper.Map<BrandDto, Brand>(new Brand());
            var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in map)
                item.Price -= (item.Price * item.Discount) / 100;

            return map;
        }
    }
}
