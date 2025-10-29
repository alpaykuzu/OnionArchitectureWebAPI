using Microsoft.Extensions.DependencyInjection;
using OnionArchitectureWebAPI.Application.Interfaces.AutoMapper;


namespace OnionArchitectureWebAPI.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddScoped<IMapper, AutoMapper.Mapper>();
        }
    }
}
