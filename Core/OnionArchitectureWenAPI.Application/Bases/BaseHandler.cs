using Microsoft.AspNetCore.Http;
using OnionArchitectureWebAPI.Application.Interfaces.AutoMapper;
using OnionArchitectureWebAPI.Application.Interfaces.UnitofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Bases
{
    public class BaseHandler
    {
        public readonly IMapper mapper;
        public readonly IUnitofWork unitOfWork;
        public readonly IHttpContextAccessor httpContextAccessor;
        public readonly Guid userId;
        public BaseHandler(IMapper mapper, IUnitofWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            if (httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                userId = Guid.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "sub").Value);
            }
        }
    }
}
