using AutoMapper;
using OnionArchitectureWebAPI.Application.Features.Auth.Command.Register;
using OnionArchitectureWebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Products.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<RegisterCommandRequest, User>();
        }
    }
}
