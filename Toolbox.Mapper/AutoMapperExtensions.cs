using Microsoft.Extensions.DependencyInjection;

namespace Toolbox.Mapper
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapperDto(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapperExtensions).Assembly);
            return service;
        }
    }
}
