using MediatR;
using Microsoft.AspNetCore.Http;
using OnionArchitectureWebAPI.Application.Bases;
using OnionArchitectureWebAPI.Application.Interfaces.AutoMapper;
using OnionArchitectureWebAPI.Application.Interfaces.UnitofWorks;
using OnionArchitectureWebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryHandler : BaseHandler, IRequestHandler<GetAllBrandsQueryRequest, IList<GetAllBrandsQueryResponse>>
    {
        public GetAllBrandsQueryHandler(IMapper mapper, IUnitofWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllBrandsQueryResponse>> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await unitOfWork.GetReadRepository<Brand>().GetAllAsync();
            var response = mapper.Map<GetAllBrandsQueryResponse, Brand>(brands);
            return response;
        }
    }
}
