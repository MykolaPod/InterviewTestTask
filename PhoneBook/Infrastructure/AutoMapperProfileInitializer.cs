using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class AutoMapperProfileInitializer
    {
        public static IServiceCollection AddAutoMapperClasses(this IServiceCollection services)
        {
            var allTypes = Assembly.GetExecutingAssembly().ExportedTypes;

            var profiles =
                allTypes
                    .Where(t => typeof(Profile).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo()))
                    .Where(t => !t.GetTypeInfo().IsAbstract);

            services.AddAutoMapper(configAction =>
            {
                var mapperConfiguration = new MapperConfiguration(cfg => { });
            }, profiles);
            return services;
        }
    }
}