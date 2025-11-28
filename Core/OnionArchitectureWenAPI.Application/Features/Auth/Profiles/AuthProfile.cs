using AutoMapper;
using OnionArchitectureWebAPI.Application.Features.Auth.Command.Register;
using OnionArchitectureWebAPI.Application.Features.Products.Command.CreateProduct;
using OnionArchitectureWebAPI.Application.Features.Products.Command.UpdateProduct;
using OnionArchitectureWebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Auth.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<CreateProductCommandRequest, Product>();
            CreateMap<UpdateProductCommandRequest, Product>();
        }
    }
}
